using System;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

using StoryGhost.Interfaces;
using StoryGhost.Models;
using StoryGhost.Models.Completions;
using StoryGhost.Util;
using StoryGhost.LogLine;

namespace StoryGhost.Services;

public class OpenAICompletionService : ICompletionService
{
    private readonly HttpClient _httpClient;

    public OpenAICompletionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private void addTokenVariationsIfFound(Dictionary<string, int> logitBias, string keyword, int keywordsLogitBias)
    {
        var suppressAmt = -100;
        var enhanceAmt = keywordsLogitBias; // experimentation results in 5 being a happy medium

        var direction = 0;

        // meaning suppress this keyword
        if (keyword.StartsWith("-"))
        {
            direction = suppressAmt;
            keyword = keyword.Substring(1); // strip out the "-"
        }
        else
        {
            direction = enhanceAmt;
        }

        if (enhanceAmt == 0) return; // nothing to enhance

        var lower = keyword.ToLower();
        var capitalized = "";

        if (keyword.Length == 1)
        {
            capitalized += keyword.ToUpper();
        }
        else
        {
            capitalized += keyword[0].ToString().ToUpper() + keyword.Substring(1);
        }

        // no space
        if (GPTTokens.Tokens.ContainsKey(lower))
        {
            var tokenId = GPTTokens.Tokens[lower].ToString();
            if (logitBias.ContainsKey(tokenId) == false)
            {
                logitBias.Add(tokenId, direction);
            }
        }

        // no space
        if (GPTTokens.Tokens.ContainsKey(capitalized))
        {
            var tokenId = GPTTokens.Tokens[capitalized].ToString();
            if (logitBias.ContainsKey(tokenId) == false)
            {
                logitBias.Add(tokenId, direction);
            }
        }

        // with space
        var lowerWithSpace = "Ġ" + lower;
        if (GPTTokens.Tokens.ContainsKey(lowerWithSpace))
        {
            var tokenId = GPTTokens.Tokens[lowerWithSpace].ToString();
            if (logitBias.ContainsKey(tokenId) == false)
            {
                logitBias.Add(tokenId, direction);
            }
        }

        // with space
        var capitalizedWithSpace = "Ġ" + capitalized;
        if (GPTTokens.Tokens.ContainsKey(capitalizedWithSpace))
        {
            var tokenId = GPTTokens.Tokens[capitalizedWithSpace].ToString();
            if (logitBias.ContainsKey(tokenId) == false)
            {
                logitBias.Add(tokenId, direction);
            }
        }
    }

    public async Task<Dictionary<string, CompletionResponse>> GetLogLineDescriptionCompletion(Plot plot, int keywordsLogitBias)
    {
        var finetunedCompletion = await getFinetunedLogLineCompletion(plot, keywordsLogitBias);

        if (plot.Keywords == null || plot.Keywords.Count == 0 || plot.Keywords.Where(k => k.StartsWith("-") == false).ToList().Count == 0)
        {
            return new Dictionary<string, CompletionResponse> { ["finetuned"] = finetunedCompletion };
        }

        // feed the initial log line completion into "instruct" which asks it to infuse the keywords into a new rewritten log line
        var keywordInfusedCompletion = await getInstructKeywordsLogLineCompletion(finetunedCompletion.Completion, plot, keywordsLogitBias - 3);

        var results = new Dictionary<string, CompletionResponse>
        {
            ["finetuned"] = finetunedCompletion,
            ["keywords"] = keywordInfusedCompletion
        };

        return results;
    }

    private async Task<CompletionResponse> getFinetunedLogLineCompletion(Plot plot, int keywordsLogitBias)
    {
        var prompt = string.Join(", ", plot.Genres.OrderBy(a => Guid.NewGuid()).ToList()) + CreateFinetuningDataset.PromptSuffix;

        /*
DELETED: "babbage:ft-personal-2022-02-25-07-36-34" = openai api fine_tunes.create -t "logline.jsonl" -m babbage --n_epochs 2 --learning_rate_multiplier 0.02
"babbage:ft-personal-2022-02-26-07-23-02" = openai api fine_tunes.create -t "logline.jsonl" -m babbage --n_epochs 2 --batch_size 64 --learning_rate_multiplier 0.1
"babbage:ft-personal-2022-02-27-22-34-14" = openai api fine_tunes.create -t "logline.jsonl" -m babbage --n_epochs 1 --batch_size 64 --learning_rate_multiplier 0.2
DELETED: "curie:ft-personal-2022-02-27-23-06-32" = openai api fine_tunes.create -t "logline.jsonl" -m curie --n_epochs 1 --batch_size 64 --learning_rate_multiplier 0.02
"curie:ft-personal-2022-02-27-23-31-57" = openai api fine_tunes.create -t "logline.jsonl" -m curie --n_epochs 2 --batch_size 64 --learning_rate_multiplier 0.08
        */

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            Model = "curie:ft-personal-2022-02-27-23-31-57", //,
            MaxTokens = 150, // longest log line prompt was 167 tokens,
            Temperature = 0.95,
            TopP = 0.99,//1.0, to avoid nonsense words, set to just below 1.0 according to https://www.reddit.com/r/GPT3/comments/tiz7tp/comment/i1hb32a/?utm_source=share&utm_medium=web2x&context=3 I'm not sure we have this problem, but seems like a good idea just in case.
            Stop = CreateFinetuningDataset.CompletionStopSequence, // IMPORTANT: this must match exactly what we used during finetuning
            PresencePenalty = 0.0, // daveshap sets penalties to 0.5 by default, maybe try? Or should I only modify if there are problems?
            FrequencyPenalty = 0.0,
            LogitBias = new Dictionary<string, int>()
        };

        //var logitBiasRatio = keywordsLogitBias / 9.0;

        //openAIRequest.PresencePenalty = Math.Max(logitBiasRatio * 1.0, 2.0);
        //openAIRequest.FrequencyPenalty = Math.Max(logitBiasRatio * 1.0, 2.0);

        if (plot.Keywords != null && plot.Keywords.Count > 0)
        {
            //openAIRequest.LogitBias = new Dictionary<string, int>();

            foreach (var keyword in plot.Keywords)
            {
                addTokenVariationsIfFound(openAIRequest.LogitBias, keyword, keywordsLogitBias);
            }
        }

        var jsonString = JsonSerializer.Serialize(openAIRequest);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("completions", content);
        //response.EnsureSuccessStatusCode(); // throws an exception if the response status code is anything but success

        if (response.IsSuccessStatusCode == false)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception(errorResponse);
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var resultDeserialized = JsonSerializer.Deserialize<OpenAICompletionsResponse>(apiResponse);

        var completionObj = resultDeserialized.Choices.FirstOrDefault();
        var completion = completionObj == null ? "" : completionObj.Text.Trim();

        var result = new CompletionResponse
        {
            Prompt = prompt,
            Completion = completion
        };

        return result;
    }

    private async Task<CompletionResponse> getInstructKeywordsLogLineCompletion(string finetunedLogLineCompletion, Plot plot, int keywordsLogitBias)
    {
        var keywordStr = Factory.GetKeywordsSentence("", plot.Keywords.Where(k => k.StartsWith("-") == false).ToList());

        var prompt = finetunedLogLineCompletion.Trim() + "\n\n" + $"You are an expert screenplay writer, summarizing the log line of an award-winning plot. Creatively rewrite the above plot teaser to focus on: {keywordStr}. It MUST include ALL {plot.Keywords.Count} of these concepts. Add a twist of irony while preserving the movie log line tone and structure." + "\n\n" + "New reworked plot log line (limit to 1 paragraph, and don't just list the keywords at the end):";

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            MaxTokens = 150, // longest log line prompt was 167 tokens,
            Temperature = 1.0,
            TopP = 0.99,//1.0, to avoid nonsense words, set to just below 1.0 according to https://www.reddit.com/r/GPT3/comments/tiz7tp/comment/i1hb32a/?utm_source=share&utm_medium=web2x&context=3 I'm not sure we have this problem, but seems like a good idea just in case.
            Stop = CreateFinetuningDataset.CompletionStopSequence, // IMPORTANT: this must match exactly what we used during finetuning
            PresencePenalty = 0.0,
            FrequencyPenalty = 0.0,
            LogitBias = new Dictionary<string, int>()
        };

        if (plot.Keywords != null && plot.Keywords.Count > 0)
        {
            openAIRequest.LogitBias = new Dictionary<string, int>();

            foreach (var keyword in plot.Keywords)
            {
                addTokenVariationsIfFound(openAIRequest.LogitBias, keyword, keywordsLogitBias);
            }
        }

        var jsonString = JsonSerializer.Serialize(openAIRequest);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var engine = "text-curie-001";
        //var engine = "text-davinci-001";

        var response = await _httpClient.PostAsync($"engines/{engine}/completions", content); // NOTE: when using the standard "instruct" series, the URL path is different than the finetuned model path

        if (response.IsSuccessStatusCode == false)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception(errorResponse);
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var resultDeserialized = JsonSerializer.Deserialize<OpenAICompletionsResponse>(apiResponse);

        var completionObj = resultDeserialized.Choices.FirstOrDefault();
        var completion = completionObj == null ? "" : completionObj.Text.Trim();

        var result = new CompletionResponse
        {
            Prompt = prompt,
            Completion = completion
        };

        return result;
    }

    public OpenAICompletionSettings getSequenceModelSettings(string targetSequence, int maxTokens, double temperature)
    {
        return new OpenAICompletionSettings
        {
            // openai api fine_tunes.create -t "ALL.jsonl" -m davinci --n_epochs 2 --learning_rate_multiplier 0.07
            ModelName = "davinci:ft-personal-2022-04-22-19-10-16",
            MaxTokens = maxTokens,
            Temperature = temperature
        };
    }

    public async Task<CompletionResponse> GetSequenceCompletion(string targetSequence, int maxTokens, double temperature, Plot story)
    {
        var promptSequenceText = CreateFinetuningDataset.GetSequenceTextUpTo(targetSequence, story);
        var prompt = Factory.GetSequencePartPrompt(targetSequence, story, promptSequenceText) + CreateFinetuningDataset.PromptSuffix;

        var modelSettings = getSequenceModelSettings(targetSequence, maxTokens, temperature);

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            Model = modelSettings.ModelName,
            MaxTokens = modelSettings.MaxTokens,
            Temperature = modelSettings.Temperature,
            TopP = 0.99,//1.0, to avoid nonsense words, set to just below 1.0 according to https://www.reddit.com/r/GPT3/comments/tiz7tp/comment/i1hb32a/?utm_source=share&utm_medium=web2x&context=3 I'm not sure we have this problem, but seems like a good idea just in case.
            Stop = CreateFinetuningDataset.CompletionStopSequence, // IMPORTANT: this must match exactly what we used during finetuning
            PresencePenalty = 0.1, // daveshap sets penalties to 0.5 by default, maybe try? Or should I only modify if there are problems?
            FrequencyPenalty = 0.1,
            LogitBias = new Dictionary<string, int>()
        };

        //var logitBiasRatio = keywordsLogitBias / 9.0;

        //openAIRequest.PresencePenalty = Math.Max(logitBiasRatio * 1.0, 2.0);
        //openAIRequest.FrequencyPenalty = Math.Max(logitBiasRatio * 1.0, 2.0);

        var jsonString = JsonSerializer.Serialize(openAIRequest);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("completions", content);
        //response.EnsureSuccessStatusCode(); // throws an exception if the response status code is anything but success

        if (response.IsSuccessStatusCode == false)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception(errorResponse);
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var resultDeserialized = JsonSerializer.Deserialize<OpenAICompletionsResponse>(apiResponse);

        var completionObj = resultDeserialized.Choices.FirstOrDefault();
        var completion = completionObj == null ? "" : completionObj.Text.Trim();

        var result = new CompletionResponse
        {
            Prompt = prompt,
            Completion = completion
        };

        return result;
    }

    public async Task<CompletionResponse> GetCharacterCompletion(Character character)
    {
        var result = await getFinetunedCharacterCompletion(character);

        return result;
    }

    private async Task<CompletionResponse> getFinetunedCharacterCompletion(Character character)
    {
        var prompt = PersonalityDescription.GetCharacterPrompt(character) + CreateFinetuningDataset.PromptSuffix;

        /*
DELETED: davinci:ft-personal-2022-04-01-06-22-16 ---- openai api fine_tunes.create -t "characters.jsonl" -m davinci --n_epochs 3 --learning_rate_multiplier 0.035
curie:ft-personal-2022-04-05-05-53-46 ---- openai api fine_tunes.create -t "characters.jsonl" -m curie --n_epochs 3 --learning_rate_multiplier 0.035
davinci:ft-personal-2022-04-05-06-09-25 ---- openai api fine_tunes.create -t "characters.jsonl" -m davinci --n_epochs 3 --learning_rate_multiplier 0.035
        */

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            Model = "davinci:ft-personal-2022-04-05-06-09-25",
            MaxTokens = 150, // longest character description completion was 88 tokens,
            Temperature = 0.99,
            TopP = 0.99,//1.0, to avoid nonsense words, set to just below 1.0 according to https://www.reddit.com/r/GPT3/comments/tiz7tp/comment/i1hb32a/?utm_source=share&utm_medium=web2x&context=3 I'm not sure we have this problem, but seems like a good idea just in case.
            Stop = CreateFinetuningDataset.CompletionStopSequence, // IMPORTANT: this must match exactly what we used during finetuning
            PresencePenalty = 0.2, // daveshap sets penalties to 0.5 by default, maybe try? Or should I only modify if there are problems?
            FrequencyPenalty = 0.2,
            LogitBias = new Dictionary<string, int>()
        };

        //var logitBiasRatio = keywordsLogitBias / 9.0;

        //openAIRequest.PresencePenalty = Math.Max(logitBiasRatio * 1.0, 2.0);
        //openAIRequest.FrequencyPenalty = Math.Max(logitBiasRatio * 1.0, 2.0);

        var jsonString = JsonSerializer.Serialize(openAIRequest);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("completions", content);
        //response.EnsureSuccessStatusCode(); // throws an exception if the response status code is anything but success

        if (response.IsSuccessStatusCode == false)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception(errorResponse);
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var resultDeserialized = JsonSerializer.Deserialize<OpenAICompletionsResponse>(apiResponse);

        var completionObj = resultDeserialized.Choices.FirstOrDefault();
        var completion = completionObj == null ? "" : completionObj.Text.Trim();

        var result = new CompletionResponse
        {
            Prompt = prompt,
            Completion = completion
        };

        return result;
    }

    public async Task<List<string>> GetTitles(List<string> genres, string logLineDescription)
    {
        var prompt = $"Genres: {string.Join(", ", genres)}";
        prompt += $"\n\nStory synopsis: {logLineDescription.Trim()}";
        prompt += $"\n\nWrite 5 movie titles for this story, ranked from best to worst:\n\n1.";

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            MaxTokens = 50, // average movie title is max of 16 tokens but typically must less
            Temperature = 1.0,
            TopP = 0.99,//1.0, to avoid nonsense words, set to just below 1.0 according to https://www.reddit.com/r/GPT3/comments/tiz7tp/comment/i1hb32a/?utm_source=share&utm_medium=web2x&context=3 I'm not sure we have this problem, but seems like a good idea just in case.
            Stop = "",
            PresencePenalty = 0.9, // helped avoid same-y titles from being generated
            FrequencyPenalty = 0.9,
            LogitBias = new Dictionary<string, int>()
        };

        var jsonString = JsonSerializer.Serialize(openAIRequest);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var engine = "text-curie-001";

        var response = await _httpClient.PostAsync($"engines/{engine}/completions", content); // NOTE: when using the standard "instruct" series, the URL path is different than the finetuned model path

        if (response.IsSuccessStatusCode == false)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception(errorResponse);
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var resultDeserialized = JsonSerializer.Deserialize<OpenAICompletionsResponse>(apiResponse);

        var completionObj = resultDeserialized.Choices.FirstOrDefault();
        var completion = completionObj == null ? "" : completionObj.Text.Trim();

        var results = new List<string>();

        foreach(var line in completion.Split("\n")) {
            var lineCleaned = line.Trim();
            lineCleaned = lineCleaned.Replace("\"", "");
            lineCleaned = lineCleaned.Replace("1.", "");
            lineCleaned = lineCleaned.Replace("2.", "");
            lineCleaned = lineCleaned.Replace("3.", "");
            lineCleaned = lineCleaned.Replace("4.", "");
            lineCleaned = lineCleaned.Replace("5.", "");
            lineCleaned = lineCleaned.Replace("6.", "");
            lineCleaned = lineCleaned.Replace("7.", "");
            lineCleaned = lineCleaned.Trim();

            if (!string.IsNullOrWhiteSpace(lineCleaned)) {
                results.Add(lineCleaned);
            }
        }

        return results;
    }
}

public class OpenAICompletionSettings
{
    public string ModelName { get; set; }
    public int MaxTokens { get; set; }
    public double Temperature { get; set; }
}