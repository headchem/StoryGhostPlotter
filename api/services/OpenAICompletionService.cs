using System;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

using StoryGhost.Interfaces;
using StoryGhost.Models;
using StoryGhost.Models.Completions;
using StoryGhost.Util;
using StoryGhost.LogLine;
using Microsoft.ApplicationInsights;

namespace StoryGhost.Services;

public class OpenAICompletionService : ICompletionService
{
    private readonly HttpClient _httpClient;
    private readonly IAnalysisService _analysisService;
    private readonly IKeywordsService _keywordService;
    private readonly IEncodingService _encodingService;
    private readonly IUserService _userService;
    private readonly IPlotService _plotService;
    private readonly ILogger<OpenAICompletionService> _logger;
    private TelemetryClient _telemetry;

    public OpenAICompletionService(ILogger<OpenAICompletionService> logger, TelemetryClient telemetry, HttpClient httpClient, IAnalysisService analysisService, IKeywordsService keywordsService, IEncodingService encodingService, IUserService userService, IPlotService plotService)
    {
        _logger = logger;
        _telemetry = telemetry;
        _httpClient = httpClient;
        _analysisService = analysisService;
        _keywordService = keywordsService;
        _encodingService = encodingService;
        _userService = userService;
        _plotService = plotService;
    }

    private async Task<CompletionResponse> getResponse(string userId, string plotId, string engineURL, OpenAICompletionsRequest openAIRequest)
    {
        if (string.IsNullOrWhiteSpace(plotId))
        {
            throw new Exception("PlotId cannot be empty!");
        }

        openAIRequest.UserId = userId;

        var jsonString = JsonSerializer.Serialize(openAIRequest);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(engineURL, content);

        if (response.IsSuccessStatusCode == false)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception(errorResponse);
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var resultDeserialized = JsonSerializer.Deserialize<OpenAICompletionsResponse>(apiResponse);

        var completionObj = resultDeserialized.Choices.FirstOrDefault();
        var completion = completionObj == null ? "" : completionObj.Text.Trim();

        var promptIsToxic = false;//await _analysisService.IsToxic(openAIRequest.Prompt);
        var completionIsToxic = await _analysisService.IsToxic(userId, completion);

        var promptTokenCount = (await _encodingService.Encode(openAIRequest.Prompt)).Count;
        var completionTokenCount = (await _encodingService.Encode(completion)).Count;

        var totalTokens = promptTokenCount + completionTokenCount;

        await _plotService.LogTokenUsage(userId, plotId, totalTokens);

        await _userService.DeductTokens(userId, totalTokens);

        var result = new CompletionResponse
        {
            Prompt = openAIRequest.Prompt,
            PromptIsToxic = promptIsToxic,
            PromptTokenCount = promptTokenCount,
            Completion = completion,
            CompletionIsToxic = completionIsToxic,
            CompletionTokenCount = completionTokenCount
        };

        return result;
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

    public async Task<Dictionary<string, CompletionResponse>> GetLogLineDescriptionCompletion(string userId, Plot plot, int keywordsLogitBias, bool bypassTokenCheck)
    {
        await ensureSufficientTokensAndOwnership(userId, plot.Id, bypassTokenCheck);

        var finetunedCompletion = await getFinetunedLogLineCompletion(userId, plot, keywordsLogitBias);

        if (plot.Keywords == null || plot.Keywords.Count == 0 || plot.Keywords.Where(k => k.StartsWith("-") == false).ToList().Count == 0)
        {
            return new Dictionary<string, CompletionResponse> { ["finetuned"] = finetunedCompletion };
        }

        // if (finetunedCompletion.CompletionIsToxic)
        // {
        //     finetunedCompletion.Completion = "The AI returned a toxic result. This means that the text contains profane language, prejudiced or hateful language, sexual content, or text that portrays certain groups/people in a harmful manner. Please adjust any existing text to guide the AI away from these topics.";

        //     return new Dictionary<string, CompletionResponse>
        //     {
        //         ["finetuned"] = finetunedCompletion,
        //         ["keywords"] = new CompletionResponse()
        //     };
        // }

        // feed the initial log line completion into "instruct" which asks it to infuse the keywords into a new rewritten log line
        var keywordInfusedCompletion = await getInstructKeywordsLogLineCompletion(userId, finetunedCompletion.Completion, plot, keywordsLogitBias - 3);

        // if (keywordInfusedCompletion.CompletionIsToxic)
        // {
        //     keywordInfusedCompletion.Completion = "The AI returned a toxic result. This means that the text contains profane language, prejudiced or hateful language, sexual content, or text that portrays certain groups/people in a harmful manner. Please adjust any existing text to guide the AI away from these topics.";
        // }

        var results = new Dictionary<string, CompletionResponse>
        {
            ["finetuned"] = finetunedCompletion,
            ["keywords"] = keywordInfusedCompletion
        };

        return results;
    }

    private async Task<CompletionResponse> getFinetunedLogLineCompletion(string userId, Plot plot, int keywordsLogitBias)
    {
        var prompt = string.Join(", ", plot.Genres.OrderBy(a => Guid.NewGuid()).ToList()) + CreateFinetuningDataset.PromptSuffix;

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            // "curie:ft-personal-2022-02-27-23-31-57" = openai api fine_tunes.create -t "logline.jsonl" -m curie --n_epochs 2 --batch_size 64 --learning_rate_multiplier 0.08
            Model = "curie:ft-personal-2022-02-27-23-31-57",
            MaxTokens = 150, // longest log line prompt was 167 tokens,
            Temperature = 0.95,
            TopP = 0.99,//1.0, to avoid nonsense words, set to just below 1.0 according to https://www.reddit.com/r/GPT3/comments/tiz7tp/comment/i1hb32a/?utm_source=share&utm_medium=web2x&context=3 I'm not sure we have this problem, but seems like a good idea just in case.
            Stop = CreateFinetuningDataset.CompletionStopSequence, // IMPORTANT: this must match exactly what we used during finetuning
            PresencePenalty = 0.0, // daveshap sets penalties to 0.5 by default, maybe try? Or should I only modify if there are problems?
            FrequencyPenalty = 0.0,
            LogitBias = new Dictionary<string, int>()
        };

        if (plot.Keywords != null && plot.Keywords.Count > 0)
        {
            foreach (var keyword in plot.Keywords)
            {
                addTokenVariationsIfFound(openAIRequest.LogitBias, keyword, keywordsLogitBias);
            }
        }

        var result = await getResponse(userId, plot.Id, "completions", openAIRequest);

        return result;
    }

    private async Task<CompletionResponse> getInstructKeywordsLogLineCompletion(string userId, string finetunedLogLineCompletion, Plot plot, int keywordsLogitBias)
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

        var result = await getResponse(userId, plot.Id, "engines/text-curie-001/completions", openAIRequest);

        return result;
    }

    public async Task<CompletionResponse> GetBlurbCompletion(string userId, string targetSequence, int maxTokens, double temperature, Plot plot, bool bypassTokenCheck)
    {
        await ensureSufficientTokensAndOwnership(userId, plot.Id, bypassTokenCheck);

        var prompt = Factory.GetSequencePartPrompt(targetSequence, plot, "blurb") + CreateFinetuningDataset.PromptSuffix;

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            // openai api fine_tunes.create -t "blurbs.jsonl" -m davinci --n_epochs 2 --learning_rate_multiplier 0.04
            Model = "davinci:ft-personal-2022-06-02-07-30-49",
            MaxTokens = maxTokens,
            Temperature = temperature,
            TopP = 0.99,//1.0, to avoid nonsense words, set to just below 1.0 according to https://www.reddit.com/r/GPT3/comments/tiz7tp/comment/i1hb32a/?utm_source=share&utm_medium=web2x&context=3 I'm not sure we have this problem, but seems like a good idea just in case.
            Stop = CreateFinetuningDataset.CompletionStopSequence, // IMPORTANT: this must match exactly what we used during finetuning
            PresencePenalty = 0.0, // daveshap sets penalties to 0.5 by default, maybe try? Or should I only modify if there are problems?
            FrequencyPenalty = 0.0,
            LogitBias = new Dictionary<string, int>()
        };

        var result = await getResponse(userId, plot.Id, "completions", openAIRequest);

        var allSequences = Factory.GetSequences();

        // remove all of the sequence name prefixes
        foreach (var seq in allSequences)
        {
            var replaceStr = (seq.Name + ":").ToUpper();
            result.Completion = result.Completion.Trim();

            if (result.Completion.StartsWith(replaceStr))
            {
                result.Completion = result.Completion.Replace(replaceStr, "");
                result.Completion = result.Completion.Trim();
            }
        }

        return result;
    }

    public async Task<CompletionResponse> GetExpandedSummaryCompletion(string userId, string targetSequence, int maxTokens, double temperature, Plot plot, bool bypassTokenCheck)
    {
        await ensureSufficientTokensAndOwnership(userId, plot.Id, bypassTokenCheck);

        var prompt = Factory.GetSequencePartPrompt(targetSequence, plot, "expanded summary") + CreateFinetuningDataset.PromptSuffix;

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            // openai api fine_tunes.create -t "expandedSummaries.jsonl" -m davinci --n_epochs 2 --learning_rate_multiplier 0.06
            Model = "davinci:ft-personal-2022-06-02-18-31-37",
            MaxTokens = maxTokens,
            Temperature = temperature,
            TopP = 0.99,//1.0, to avoid nonsense words, set to just below 1.0 according to https://www.reddit.com/r/GPT3/comments/tiz7tp/comment/i1hb32a/?utm_source=share&utm_medium=web2x&context=3 I'm not sure we have this problem, but seems like a good idea just in case.
            Stop = CreateFinetuningDataset.CompletionStopSequence, // IMPORTANT: this must match exactly what we used during finetuning
            PresencePenalty = 0.0, // daveshap sets penalties to 0.5 by default, maybe try? Or should I only modify if there are problems?
            FrequencyPenalty = 0.0,
            LogitBias = new Dictionary<string, int>()
        };

        var result = await getResponse(userId, plot.Id, "completions", openAIRequest);

        // if (result.CompletionIsToxic) {
        //     result.Completion = "The AI returned a toxic result. This means that the text contains profane language, prejudiced or hateful language, sexual content, or text that portrays certain groups/people in a harmful manner. Please adjust any existing text to guide the AI away from these topics.";
        // }

        var allSequences = Factory.GetSequences();

        // remove all of the sequence name prefixes
        foreach (var seq in allSequences)
        {
            var replaceStr = (seq.Name + ":").ToUpper();
            result.Completion = result.Completion.Trim();

            if (result.Completion.StartsWith(replaceStr))
            {
                result.Completion = result.Completion.Replace(replaceStr, "");
                result.Completion = result.Completion.Trim();
            }
        }

        return result;
    }

    public async Task<CompletionResponse> GetFullCompletion(string userId, string targetSequence, int maxTokens, double temperature, Plot story, bool bypassTokenCheck)
    {
        // TODO: check if tokens exist, deduct tokens
        var result = new CompletionResponse();

        result.Prompt = "TODO";
        result.Completion = "AI FULL completion for " + targetSequence + " goes here...";

        return result;
    }
    public async Task<CompletionResponse> GetCharacterCompletion(string userId, string plotId, Character character, bool bypassTokenCheck)
    {
        await ensureSufficientTokensAndOwnership(userId, plotId, bypassTokenCheck);

        var result = await getFinetunedCharacterCompletion(userId, plotId, character);

        return result;
    }

    private async Task<CompletionResponse> getFinetunedCharacterCompletion(string userId, string plotId, Character character)
    {
        var prompt = PersonalityDescription.GetCharacterPrompt(character) + CreateFinetuningDataset.PromptSuffix;

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            // openai api fine_tunes.create -t "characters.jsonl" -m davinci --n_epochs 3 --learning_rate_multiplier 0.035
            Model = "davinci:ft-personal-2022-04-05-06-09-25",
            MaxTokens = 150, // longest character description completion was 88 tokens,
            Temperature = 0.99,
            TopP = 0.99,//1.0, to avoid nonsense words, set to just below 1.0 according to https://www.reddit.com/r/GPT3/comments/tiz7tp/comment/i1hb32a/?utm_source=share&utm_medium=web2x&context=3 I'm not sure we have this problem, but seems like a good idea just in case.
            Stop = CreateFinetuningDataset.CompletionStopSequence, // IMPORTANT: this must match exactly what we used during finetuning
            PresencePenalty = 0.2, // daveshap sets penalties to 0.5 by default, maybe try? Or should I only modify if there are problems?
            FrequencyPenalty = 0.2,
            LogitBias = new Dictionary<string, int>()
        };

        var result = await getResponse(userId, plotId, "completions", openAIRequest);

        // if (result.CompletionIsToxic)
        // {
        //     result.Completion = "The AI returned a toxic result. This means that the text contains profane language, prejudiced or hateful language, sexual content, or text that portrays certain groups/people in a harmful manner. Please adjust any existing text to guide the AI away from these topics.";
        // }

        return result;
    }

    public async Task<TitlesResponse> GetTitles(string userId, string plotId, List<string> genres, string logLineDescription, bool bypassTokenCheck)
    {
        await ensureSufficientTokensAndOwnership(userId, plotId, bypassTokenCheck);

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
            PresencePenalty = 0.9, // helped avoid same-y titles from being generated. We also don't expect much punctuation in Titles, so no concerns with suppressing common characters
            FrequencyPenalty = 0.9,
            LogitBias = new Dictionary<string, int>()
        };

        var openAIResult = await getResponse(userId, plotId, "engines/text-curie-001/completions", openAIRequest);

        // if (openAIResult.CompletionIsToxic) {
        //     openAIResult.Completion = "The AI returned toxic results.";
        // }

        var titleResults = removeListNumbers(openAIResult.Completion);

        var result = new TitlesResponse();
        result.Titles = titleResults;
        result.CompletionResponse = openAIResult;

        return result;
    }

    private List<string> removeListNumbers(string completion)
    {
        var results = new List<string>();

        foreach (var line in completion.Split("\n"))
        {
            var lineCleaned = line.Trim();
            lineCleaned = lineCleaned.Replace("\"", "");
            lineCleaned = lineCleaned.Replace("1.", "");
            lineCleaned = lineCleaned.Replace("2.", "");
            lineCleaned = lineCleaned.Replace("3.", "");
            lineCleaned = lineCleaned.Replace("4.", "");
            lineCleaned = lineCleaned.Replace("5.", "");
            lineCleaned = lineCleaned.Replace("6.", "");
            lineCleaned = lineCleaned.Replace("7.", "");
            lineCleaned = lineCleaned.Replace("8.", "");
            lineCleaned = lineCleaned.Replace("9.", "");
            lineCleaned = lineCleaned.Trim();

            if (!string.IsNullOrWhiteSpace(lineCleaned))
            {
                results.Add(lineCleaned);
            }
        }

        return results;
    }

    public async Task<(List<UserSequence>, int)> GenerateAllSequences(string userId, Plot plot, string upToTargetSequenceExclusive)
    {
        await ensureSufficientTokensAndOwnership(userId, plot.Id, false);

        var sequenceList = getRandomSequenceList(upToTargetSequenceExclusive);

        var results = new List<UserSequence>();

        var totalTokenCount = 0;

        foreach (var targetSequence in sequenceList)
        {
            var sequenceResponse = await GetExpandedSummaryCompletion(userId, targetSequence, 256, 0.8, plot, true);
            totalTokenCount += sequenceResponse.PromptTokenCount + sequenceResponse.CompletionTokenCount;

            var sequence = new UserSequence
            {
                SequenceName = targetSequence,
                Text = sequenceResponse.Completion,
                Completions = new List<CompletionResponse> { sequenceResponse }
            };

            results.Add(sequence);
            plot.Sequences = results; // we need to update the story sequences after each loop so that it has the previous events to include in the next sequence's prompt
        }

        return (results, totalTokenCount);
    }

    // returns a list of target sequence names in a random plausible order. The various possible orders are from the training data. For example, sometime the B Story comes after Catalyst, sometimes after Theme Stated.
    private List<string> getRandomSequenceList(string upToTargetSequenceExclusive)
    {
        // all sequences end with this order
        var ending = new List<string>{
            "Fun And Games",
            "Midpoint",
            "Bad Guys Close In",
            "All Hope Is Lost",
            "Dark Night Of The Soul",
            "Break Into Three",
            "Climax",
            "Cooldown"
        };

        var variations = new List<List<string>>{
            // Aladdin
            new List<string>{
                "Opening Image",
                "Setup",
                "Theme Stated",
                "Catalyst",
                "B Story",
                "Debate",
                "Break Into Two"
            },

            // Whiplash
            new List<string>{
                "Opening Image",
                "Theme Stated",
                "Setup",
                "Catalyst",
                "Debate",
                "Break Into Two",
                "B Story"
            },

            // Star Wars
            new List<string>{
                "Opening Image",
                "Theme Stated",
                "Setup",
                "Catalyst",
                "B Story",
                "Debate",
                "Break Into Two"
            },

            // Iron Man
            new List<string>{
                "Opening Image",
                "Setup",
                "Theme Stated",
                "B Story",
                "Catalyst",
                "Debate",
                "Break Into Two"
            },

            // Elf
            new List<string>{
                "Opening Image",
                "Setup",
                "Theme Stated",
                "Catalyst",
                "Debate",
                "Break Into Two",
                "B Story",
            },

            // Soul
            new List<string>{
                "Opening Image",
                "Setup",
                "Catalyst",
                "Debate",
                "Theme Stated",
                "Break Into Two",
                "B Story",
            }
        };

        variations = variations.OrderBy(x => Guid.NewGuid()).ToList();

        var randomList = variations.First();

        randomList = randomList.Concat(ending).ToList();

        randomList = keepUpToTargetSequence(randomList, upToTargetSequenceExclusive);

        return randomList;
    }

    private List<string> keepUpToTargetSequence(List<string> sequences, string upToTargetSequenceExclusive)
    {
        // "All" is a special signal to return all sequences including Cooldown
        if (upToTargetSequenceExclusive == "All") return sequences;

        var results = new List<string>();

        foreach (var sequence in sequences)
        {
            if (sequence == upToTargetSequenceExclusive) return results;

            results.Add(sequence);
        }

        return results;
    }

    public async Task<(Plot, int)> GenerateAllLogLine(string userId, string plotId, List<string> genres)
    {
        await ensureSufficientTokensAndOwnership(userId, plotId, false);

        var totalTokens = 0;

        var keywords = _keywordService.GetKeywords(genres, 4);

        var logLineDescCompletion = await GetLogLineDescriptionCompletion(userId, new Plot
        {
            Id = plotId,
            Genres = genres,
            Keywords = keywords
        }, 4, true);
        var logLineDesc = logLineDescCompletion["keywords"].Completion;

        totalTokens += logLineDescCompletion["finetuned"].PromptTokenCount + logLineDescCompletion["finetuned"].CompletionTokenCount + logLineDescCompletion["keywords"].PromptTokenCount + logLineDescCompletion["keywords"].CompletionTokenCount;

        var titleCompletion = await GetTitles(userId, plotId, genres, logLineDesc, true);
        totalTokens += titleCompletion.CompletionResponse.PromptTokenCount + titleCompletion.CompletionResponse.CompletionTokenCount;

        var firstTitle = titleCompletion.Titles.First();

        return (new Plot
        {
            Id = plotId,
            Keywords = keywords,
            LogLineDescription = logLineDesc,
            Title = firstTitle,
            ProblemTemplate = Factory.GetProblemTemplates().OrderBy(x => Guid.NewGuid()).First().Id,
            DramaticQuestion = Factory.GetDramaticQuestions().OrderBy(x => Guid.NewGuid()).First().Id
        }, totalTokens);
    }

    public async Task<(List<Character>, int)> GenerateAllCharacters(string userId, string plotId, string LogLineDescription, string ProblemTemplate, string DramaticQuestion)
    {
        await ensureSufficientTokensAndOwnership(userId, plotId, false);

        var rand = new Random();

        var characters = new List<Character>();
        var numCharacters = (int)rand.NextInt64(2, 5);

        var names = await getCharacterNames(userId, plotId, LogLineDescription, numCharacters);

        var remainingArchetypes = Factory.GetArchetypes().Select(a => a.Id).OrderBy(x => Guid.NewGuid()).ToList();

        var totalTokenCount = 0;

        foreach (var name in names)
        {
            // foreach Character, choose a random Archetype which removes it from being an option for subsequent characters
            var archetype = remainingArchetypes[0];
            remainingArchetypes.Remove(archetype);

            // Randomize Personality based on preferences of the Archetype - find old code that did this - any way to avoid personalities that are too similar to existing characters? Try without for now, maybe the archetype-without-replacement thing will help avoid naturally
            var personality = getRandomPersonality(archetype);

            var character = new Character
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Archetype = archetype,
                Personality = personality,
                Description = "",
                IsHero = names.First() == name
            };

            // Generate Description for each Character based on Name, Archetype, Personality
            var characterResponse = await getFinetunedCharacterCompletion(userId, plotId, character);
            totalTokenCount += characterResponse.PromptTokenCount + characterResponse.CompletionTokenCount;

            character.Description = characterResponse.Completion;

            characters.Add(character);
        }

        return (characters, totalTokenCount);
    }

    ///<summary>extract any names from LogLineDesc and use these names first, fallback to randomly selected names from a list if more characters are needed to fill a randomized 2-4 spots. The first name returned will always be the protagonist.</summary>
    private async Task<List<string>> getCharacterNames(string userId, string plotId, string LogLineDescription, int numCharacters)
    {
        // Ask GPT-3 to decide who the Hero is according to the LogLineDesc, and make them the first Character in list

        var prompt = LogLineDescription;
        prompt += $"\n\nList all of the named characters that appear in the above summary, starting with the protagonist:";
        prompt += $"\n\n1.";

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            MaxTokens = 48,
            Temperature = 0.0, // low temp seems to work well for NER
            TopP = 1.0, // some names may be super weird, so we allow all token combinations
            Stop = "6.", // if it gets this far, we want to stop and only consider the first 5 it finds
            PresencePenalty = 1.0, // high penalty to avoid repetition of already found names. Since we don't expect repeated punctuation due to the increasing numbers in the list, I think this higher penalty is ok
            FrequencyPenalty = 1.0,
            LogitBias = new Dictionary<string, int>()
        };

        // smallest Ada model was usually accurate enough. NOTE: names like "Tinker Bell" or "Spiderman" will not appear in the list of 7000 most popular names, so they will be filtered out.
        var result = await getResponse(userId, plotId, "engines/text-ada-001/completions", openAIRequest);

        var results = removeListNumbers(result.Completion);

        // remove any empty entries
        results = results.Where(n => string.IsNullOrWhiteSpace(n) == false).ToList();

        // remove any words that don't start with a capital letter, like "the townspeople".
        results = results.Where(n => char.IsUpper(n[0])).ToList();

        var stopwords = new List<string>{
            "the ",
            "himself",
            "herself",
            "friends",
            "family"
        };

        results = results.Where(name => stopwords.Any(stopword => name.ToLower().StartsWith(stopword.ToLower()) == false)).ToList(); // filter out any that start with known stopwords, ex: "The townspeople"

        // filter results by requiring that the first name appear in the list of known first names (~7000 most popular)
        results = results.Where(name => CharacterNames.FirstNames.Contains(name.Split(' ')[0])).ToList();

        Random rand = new Random();

        while (results.Count() < numCharacters)
        {
            // randomly select more names until we've hit numCharacters
            var newCharName = CharacterNames.FirstNames.ElementAt(rand.Next(CharacterNames.FirstNames.Count));

            results.Add(newCharName);
        }

        return results;
    }

    private Personality getRandomPersonality(string archetype)
    {
        var archetypeObj = Factory.GetArchetype(archetype);

        var personality = new Personality
        {
            ClosemindedToImaginative = getPersonalityComponent(archetypeObj.PersonalityTendencies.ClosemindedToImaginativeTendency),
            DisciplinedToSpontaneous = getPersonalityComponent(archetypeObj.PersonalityTendencies.DisciplinedToSpontaneousTendency),
            IntrovertToExtrovert = getPersonalityComponent(archetypeObj.PersonalityTendencies.IntrovertToExtrovertTendency),
            ColdToEmpathetic = getPersonalityComponent(archetypeObj.PersonalityTendencies.ColdToEmpatheticTendency),
            UnflappableToAnxious = getPersonalityComponent(archetypeObj.PersonalityTendencies.UnflappableToAnxiousTendency)
        };

        return personality;
    }

    private PersonalityComponent getPersonalityComponent(double bias)
    {
        var rand = new Random();
        var primary = (rand.NextDouble() * 2.0) - 1.0 + bias;
        var aspect = (rand.NextDouble() * 2.0) - 1.0 + bias;

        primary = Math.Round(primary * 2, MidpointRounding.AwayFromZero) / 2;
        aspect = Math.Round(aspect * 2, MidpointRounding.AwayFromZero) / 2;

        primary = Math.Clamp(primary, -1.0, 1.0);

        if (primary == 0)
        {
            aspect = 0; // if primary is exactly neutral, then aspect must also be in the center
        }
        else if (Math.Abs(primary) == 1.0)
        {
            aspect = Math.Clamp(aspect, -1.0, 1.0);
        }
        else
        {
            aspect = Math.Clamp(aspect, -0.5, 0.5); // if the primary isn't extreme, then the aspect can't be extreme either
        }

        return new PersonalityComponent
        {
            Primary = primary,
            Aspect = aspect
        };
    }

    private async Task ensureSufficientTokensAndOwnership(string userId, string plotId, bool bypassTokenCheck)
    {
        if (string.IsNullOrWhiteSpace(userId)) throw new Exception("UserId must not be empty");
        if (string.IsNullOrWhiteSpace(plotId)) throw new Exception("PlotId must not be empty");

        using (_logger.BeginScope(new Dictionary<string, object>
        {
            ["UserId"] = userId,
            ["PlotId"] = plotId
        }))
        {
            // ensure that plotId is owned by userId
            var plot = await _plotService.GetPlot(userId, plotId);
            if (plot.UserId != userId)
            {
                throw new Exception($"UserId {userId} does not own PlotId {plotId}");
            }

            var tokensRemaining = await _userService.GetTokensRemaining(userId);

            if (tokensRemaining <= -1 * 2048 * 16)
            {
                throw new Exception($"User attempted completion even though they have an extremely negative token balance. This is suspicious behavior that should be investigated. UserId: {userId}, PlotId: {plotId}, tokensRemaining: {tokensRemaining}");
            }

            if (bypassTokenCheck == false)
            {
                // ensure user has more than 0 tokens remaining

                if (tokensRemaining <= 0)
                {
                    throw new Exception("User is out of tokens, unable to generate completion");
                }
            }
        }
    }
}