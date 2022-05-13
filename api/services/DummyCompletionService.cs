using System;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using StoryGhost.Interfaces;
using StoryGhost.Models;
using StoryGhost.Models.Completions;
using StoryGhost.Util;
using StoryGhost.LogLine;
using StoryGhost.Util;

namespace StoryGhost.Services;

public class DummyCompletionService : ICompletionService
{

    private readonly HttpClient _httpClient;
    private readonly IEncodingService _encodingService;
    private readonly IUserService _userService;

    public DummyCompletionService(HttpClient httpClient, IEncodingService encodingService, IUserService userService)
    {
        _httpClient = httpClient;
        _encodingService = encodingService;
        _userService = userService;
    }

    public async Task<Dictionary<string, CompletionResponse>> GetLogLineDescriptionCompletion(string userId, Plot story, int keywordsLogitBias)
    {
        var prompt = "TODO log line desc prompt goes here...";

        var result = new CompletionResponse();

        result.Prompt = prompt;
        result.Completion = "AI Log Line Description completion goes here...";

        var promptTokenCount = (await _encodingService.Encode(result.Prompt)).Count;
        var completionTokenCount = (await _encodingService.Encode(result.Completion)).Count;

        var totalTokens = promptTokenCount + completionTokenCount;

        await _userService.DeductTokens(userId, totalTokens);

        return new Dictionary<string, CompletionResponse> {
            ["finetuned"] = result,
            ["keywords"] = result
            };
    }

    public async Task<CompletionResponse> GetSequenceCompletion(string userId, string targetSequence, int maxTokens, double temperature, Plot story)
    {
        //var prompt = Factory.GetSequencePrompt(sequenceName, story);

        var promptSequenceText = CreateFinetuningDataset.GetSequenceTextUpTo(targetSequence, story);
        var prompt = Factory.GetSequencePartPrompt(targetSequence, story, promptSequenceText);

        var result = new CompletionResponse();

        result.Prompt = prompt;
        result.Completion = "AI SEQUENCE completion for " + targetSequence + " goes here...";

        var promptTokenCount = (await _encodingService.Encode(result.Prompt)).Count;
        var completionTokenCount = (await _encodingService.Encode(result.Completion)).Count;

        var totalTokens = promptTokenCount + completionTokenCount;

        await _userService.DeductTokens(userId, totalTokens);

        return result;
    }

    public async Task<CompletionResponse> GetCharacterCompletion(string userId, Character character)
    {
        var prompt = "TODO character archetype prompt goes here...";

        var result = new CompletionResponse();

        result.Prompt = prompt;
        result.Completion = "AI CHARACTER completion goes here...";

        var promptTokenCount = (await _encodingService.Encode(result.Prompt)).Count;
        var completionTokenCount = (await _encodingService.Encode(result.Completion)).Count;

        var totalTokens = promptTokenCount + completionTokenCount;

        await _userService.DeductTokens(userId, totalTokens);

        return result;
    }

    public async Task<TitlesResponse> GetTitles(string userId, List<string> genres, string logLineDescription)
    {
        return new TitlesResponse
        {
            Titles = new List<string>
            {
                "Title 1",
                "Title 2",
                "Title 3",
                "Title 4",
                "Title 5"
            },
            CompletionResponse = new CompletionResponse
            {
                Prompt = "titles prompt goes here",
                Completion = "titles completion goes here",
                PromptTokenCount = 123,
                CompletionTokenCount = 444
            }
        };
    }

    public async Task<(List<UserSequence>, int)> GenerateAllSequences(string userId, Plot story, string upToTargetSequenceExclusive)
    {
        return (new List<UserSequence>(), 123);
    }

    public async Task<(Plot, int)> GenerateAllLogLine(string userId, List<string> genres)
    {
        return (new Plot
        {
            Keywords = new List<string> { "keyword 1", "keyword 2" },
            Title = "TESTING edit here...",
            LogLineDescription = "auto gen log line desc goes here",
            ProblemTemplate = Factory.GetProblemTemplates().OrderBy(x => Guid.NewGuid()).First().Name,
            DramaticQuestion = Factory.GetDramaticQuestions().OrderBy(x => Guid.NewGuid()).First().Name
        }, 123);
    }

    public async Task<(List<Character>, int)> GenerateAllCharacters(string userId, string LogLineDescription, string ProblemTemplate, string DramaticQuestion)
    {
        return (new List<Character> {
            new Character {
                Id = Guid.NewGuid().ToString(),
                Name = "John",
                Archetype = "explorer",
                Personality = new Personality{
                    ClosemindedToImaginative = new PersonalityComponent{
                        Primary = 1.0,
                        Aspect = -0.5
                    },
                    DisciplinedToSpontaneous = new PersonalityComponent{
                        Primary = 1.0,
                        Aspect = -0.5
                    },
                    IntrovertToExtrovert = new PersonalityComponent{
                        Primary = 1.0,
                        Aspect = -0.5
                    },
                    ColdToEmpathetic = new PersonalityComponent{
                        Primary = 1.0,
                        Aspect = -0.5
                    },
                    UnflappableToAnxious = new PersonalityComponent{
                        Primary = 1.0,
                        Aspect = -0.5
                    },
                },
                Description = "John's description goes here",
                IsHero = true
            },
            new Character {
                Id = Guid.NewGuid().ToString(),
                Name = "Rachel",
                Archetype = "innocent",
                Personality = new Personality{
                    ClosemindedToImaginative = new PersonalityComponent{
                        Primary = 0.5,
                        Aspect = 0.5
                    },
                    DisciplinedToSpontaneous = new PersonalityComponent{
                        Primary = -0.5,
                        Aspect = 0.5
                    },
                    IntrovertToExtrovert = new PersonalityComponent{
                        Primary = -1.0,
                        Aspect = 0.5
                    },
                    ColdToEmpathetic = new PersonalityComponent{
                        Primary = 0.0,
                        Aspect = 0.5
                    },
                    UnflappableToAnxious = new PersonalityComponent{
                        Primary = 1.0,
                        Aspect = 0.5
                    },
                },
                Description = "Rachel's description goes here"
            },
        }, 123);
    }

}