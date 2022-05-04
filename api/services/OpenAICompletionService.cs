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
    private readonly IKeywordsService _keywordService;

    public OpenAICompletionService(HttpClient httpClient, IKeywordsService keywordsService)
    {
        _httpClient = httpClient;
        _keywordService = keywordsService;
    }

    private async Task<CompletionResponse> getResponse(string engineURL, OpenAICompletionsRequest openAIRequest)
    {
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

        var result = new CompletionResponse
        {
            Prompt = openAIRequest.Prompt,
            Completion = completion
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

        var result = await getResponse("completions", openAIRequest);

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

        var result = await getResponse("engines/text-curie-001/completions", openAIRequest);

        return result;
    }

    public async Task<CompletionResponse> GetSequenceCompletion(string targetSequence, int maxTokens, double temperature, Plot story)
    {
        var promptSequenceText = CreateFinetuningDataset.GetSequenceTextUpTo(targetSequence, story);
        var prompt = Factory.GetSequencePartPrompt(targetSequence, story, promptSequenceText) + CreateFinetuningDataset.PromptSuffix;

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            Model = "davinci:ft-personal-2022-04-22-19-10-16",
            MaxTokens = maxTokens,
            Temperature = temperature,
            TopP = 0.99,//1.0, to avoid nonsense words, set to just below 1.0 according to https://www.reddit.com/r/GPT3/comments/tiz7tp/comment/i1hb32a/?utm_source=share&utm_medium=web2x&context=3 I'm not sure we have this problem, but seems like a good idea just in case.
            Stop = CreateFinetuningDataset.CompletionStopSequence, // IMPORTANT: this must match exactly what we used during finetuning
            PresencePenalty = 0.1, // daveshap sets penalties to 0.5 by default, maybe try? Or should I only modify if there are problems?
            FrequencyPenalty = 0.1,
            LogitBias = new Dictionary<string, int>()
        };

        var result = await getResponse("completions", openAIRequest);

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

    public async Task<CompletionResponse> GetCharacterCompletion(Character character)
    {
        var result = await getFinetunedCharacterCompletion(character);

        return result;
    }

    private async Task<CompletionResponse> getFinetunedCharacterCompletion(Character character)
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

        var result = await getResponse("completions", openAIRequest);

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
            PresencePenalty = 0.9, // helped avoid same-y titles from being generated. We also don't expect much punctuation in Titles, so no concerns with suppressing common characters
            FrequencyPenalty = 0.9,
            LogitBias = new Dictionary<string, int>()
        };

        var result = await getResponse("engines/text-curie-001/completions", openAIRequest);

        var results = removeListNumbers(result.Completion);

        return results;
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

    public async Task<List<UserSequence>> GenerateAllSequences(Plot story, string upToTargetSequenceExclusive)
    {
        var sequenceList = getRandomSequenceList(upToTargetSequenceExclusive);

        var results = new List<UserSequence>();

        foreach (var targetSequence in sequenceList)
        {
            var sequenceText = await GetSequenceCompletion(targetSequence, 256, 0.8, story);
            var sequence = new UserSequence
            {
                SequenceName = targetSequence,
                Text = sequenceText.Completion,
                Completions = new List<string> { sequenceText.Completion }
            };

            results.Add(sequence);
            story.Sequences = results; // we need to update the story sequences after each loop so that it has the previous events to include in the next sequence's prompt
        }

        return results;
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

    public async Task<Plot> GenerateAllLogLine(List<string> genres)
    {
        var keywords = _keywordService.GetKeywords(genres, 4);
        var logLineDesc = (await GetLogLineDescriptionCompletion(new Plot
        {
            Genres = genres,
            Keywords = keywords
        }, 4))["keywords"].Completion;
        var title = (await GetTitles(genres, logLineDesc)).First();

        return new Plot
        {
            Keywords = keywords,
            LogLineDescription = logLineDesc,
            Title = title,
            ProblemTemplate = Factory.GetProblemTemplates().OrderBy(x => Guid.NewGuid()).First().Id,
            DramaticQuestion = Factory.GetDramaticQuestions().OrderBy(x => Guid.NewGuid()).First().Id
        };
    }

    public async Task<List<Character>> GenerateAllCharacters(string LogLineDescription, string ProblemTemplate, string DramaticQuestion)
    {
        var rand = new Random();

        var characters = new List<Character>();
        var numCharacters = (int)rand.NextInt64(2, 5);

        var names = await getCharacterNames(LogLineDescription, numCharacters);

        var remainingArchetypes = Factory.GetArchetypes().Select(a => a.Id).OrderBy(x => Guid.NewGuid()).ToList();

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
            var characterDescription = await getFinetunedCharacterCompletion(character);

            character.Description = characterDescription.Completion;

            characters.Add(character);
        }

        return characters;
    }

    ///<summary>extract any names from LogLineDesc and use these names first, fallback to randomly selected names from a list if more characters are needed to fill a randomized 2-4 spots. The first name returned will always be the protagonist.</summary>
    private async Task<List<string>> getCharacterNames(string LogLineDescription, int numCharacters)
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

        // smallest Ada model was accurate enough
        var result = await getResponse("engines/text-ada-001/completions", openAIRequest);

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
}