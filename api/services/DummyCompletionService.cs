using System;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

using StoryGhost.Interfaces;
using StoryGhost.Models;
using StoryGhost.Models.Completions;
using StoryGhost.Util;
using StoryGhost.LogLine;

namespace StoryGhost.Services;

public class DummyCompletionService : ICompletionService
{

    private readonly ILogger<DummyCompletionService> _logger;
    private readonly HttpClient _httpClient;
    private readonly IUserService _userService;

    public DummyCompletionService(ILogger<DummyCompletionService> logger, HttpClient httpClient, IUserService userService)
    {
        _logger = logger;
        _httpClient = httpClient;
        _userService = userService;
    }

    public async Task<CompletionResponse> GetLogLineDescriptionCompletion(string userId, double temperature, Plot story, int keywordsLogitBias, bool bypassTokenCheck)
    {
        using (_logger.BeginScope(new Dictionary<string, object> { ["UserId"] = userId }))
        {
            var tokensRemaining = await _userService.GetTokensRemaining(userId);
            if (tokensRemaining <= 0)
            {
                throw new Exception("User is out of tokens, unable to generate completion");
            }
        }

        var prompt = "TODO log line desc prompt goes here...";

        var result = new CompletionResponse();

        result.Id = Guid.NewGuid().ToString();
        result.Prompt = prompt;
        result.Completion = "AI Log Line Description completion goes here...";

        var promptTokenCount = 123;
        var completionTokenCount = 456;

        var totalTokens = promptTokenCount + completionTokenCount;

        await _userService.DeductTokens(userId, totalTokens);

        return result;
    }

    public async Task<List<CompletionResponse>> GetBlurbCompletion(string userId, string targetSequence, int maxTokens, double temperature, Plot story, bool bypassTokenCheck, int numCompletions)
    {
        // TODO: check if tokens exist, deduct tokens
        var result = new CompletionResponse();

        result.Id = Guid.NewGuid().ToString();
        result.Prompt = "TODO";
        result.Completion = "AI BLURB completion for " + targetSequence + " goes here...";

        return new List<CompletionResponse> { result };
    }

    public async Task<List<CompletionResponse>> GetExpandedSummaryCompletion(string userId, string targetSequence, int maxTokens, double temperature, Plot story, bool bypassTokenCheck, int numCompletions)
    {
        using (_logger.BeginScope(new Dictionary<string, object> { ["UserId"] = userId }))
        {
            var tokensRemaining = await _userService.GetTokensRemaining(userId);
            if (tokensRemaining <= 0)
            {
                throw new Exception("User is out of tokens, unable to generate completion");
            }
        }

        var prompt = Factory.GetSequencePartPrompt(targetSequence, story, "expanded summary");

        var result = new CompletionResponse();

        result.Id = Guid.NewGuid().ToString();
        result.Prompt = prompt;
        result.Completion = "AI EXPANDED SUMMARY completion for " + targetSequence + " goes here...";

        var promptTokenCount = 123;
        var completionTokenCount = 456;

        var totalTokens = promptTokenCount + completionTokenCount;

        await _userService.DeductTokens(userId, totalTokens);

        return new List<CompletionResponse> { result };
    }

    public async Task<List<CompletionResponse>> GetSceneSummaryCompletion(string userId, string plotId, string sceneFullScreenplay, List<string> characterNames, int maxTokens, double temperature, bool bypassTokenCheck, int numCompletions)
    {
        
        {
            var tokensRemaining = await _userService.GetTokensRemaining(userId);
            if (tokensRemaining <= 0)
            {
                throw new Exception("User is out of tokens, unable to generate completion");
            }
        }

        var prompt = sceneFullScreenplay;

        var result = new CompletionResponse();

        result.Id = Guid.NewGuid().ToString();
        result.Prompt = prompt;
        result.Completion = "AI SCENE SUMMARY goes here...";

        var promptTokenCount = 123;
        var completionTokenCount = 456;

        var totalTokens = promptTokenCount + completionTokenCount;

        await _userService.DeductTokens(userId, totalTokens);

        return new List<CompletionResponse> { result };
    }

    public async Task<List<CompletionResponse>> GetSummaryReducerCompletion(string userId, string plotId, string longText, List<string> characterNames, int maxTokens, double temperature, bool bypassTokenCheck, int numCompletions)
    {
        
        {
            var tokensRemaining = await _userService.GetTokensRemaining(userId);
            if (tokensRemaining <= 0)
            {
                throw new Exception("User is out of tokens, unable to generate completion");
            }
        }

        var prompt = longText;

        var result = new CompletionResponse();

        result.Id = Guid.NewGuid().ToString();
        result.Prompt = prompt;
        result.Completion = "AI summary reducer goes here...";

        var promptTokenCount = 123;
        var completionTokenCount = 456;

        var totalTokens = promptTokenCount + completionTokenCount;

        await _userService.DeductTokens(userId, totalTokens);

        return new List<CompletionResponse> { result };
    }

    public async Task<List<CompletionResponse>> GetFullCompletion(string userId, string targetSequence, int maxTokens, double temperature, Plot story, bool bypassTokenCheck, int numCompletions)
    {
        // TODO: check if tokens exist, deduct tokens
        var result = new CompletionResponse();

        result.Id = Guid.NewGuid().ToString();
        result.Prompt = "TODO";
        result.Completion = "AI FULL completion for " + targetSequence + " goes here...";

        return new List<CompletionResponse> { result };
    }

    public async Task<CompletionResponse> GetCharacterCompletion(string userId, string plotId, double temperature, Character character, bool bypassTokenCheck)
    {
        using (_logger.BeginScope(new Dictionary<string, object> { ["UserId"] = userId }))
        {
            var tokensRemaining = await _userService.GetTokensRemaining(userId);
            if (tokensRemaining <= 0)
            {
                throw new Exception("User is out of tokens, unable to generate completion");
            }
        }

        var prompt = "TODO character archetype prompt goes here...";

        var result = new CompletionResponse();

        result.Id = Guid.NewGuid().ToString();
        result.Prompt = prompt;
        result.Completion = "AI CHARACTER completion goes here...";

        var promptTokenCount = 123;
        var completionTokenCount = 456;

        var totalTokens = promptTokenCount + completionTokenCount;

        await _userService.DeductTokens(userId, totalTokens);

        return result;
    }

    public async Task<TitlesResponse> GetTitles(string userId, string plotId, List<string> genres, string logLineDescription, bool bypassTokenCheck)
    {
        using (_logger.BeginScope(new Dictionary<string, object> { ["UserId"] = userId }))
        {
            var tokensRemaining = await _userService.GetTokensRemaining(userId);
            if (tokensRemaining <= 0)
            {
                throw new Exception("User is out of tokens, unable to generate completion");
            }
        }

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
                Id = Guid.NewGuid().ToString(),
                Prompt = "titles prompt goes here",
                Completion = "titles completion goes here",
                PromptTokenCount = 123,
                CompletionTokenCount = 444
            }
        };
    }

    public async Task<(Plot, int)> GenerateAllLogLine(string userId, string plotId, List<string> genres)
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

    public async Task<(Character, CompletionResponse)> GenerateCharacter(string userId, string plotId, Character curCharacter, List<Character> existingCharacters, string LogLineDescription, bool useTokens)
    {
        var isHero = false;

        if (existingCharacters.Where(c => c.IsHero).FirstOrDefault() == null)
        {
            isHero = true;
        }

        return (new Character
        {
            Id = Guid.NewGuid().ToString(),
            Name = "John",
            Archetype = "explorer",
            Personality = new Personality
            {
                ClosemindedToImaginative = new PersonalityComponent
                {
                    Primary = 1.0,
                    Aspect = -0.5
                },
                DisciplinedToSpontaneous = new PersonalityComponent
                {
                    Primary = 1.0,
                    Aspect = -0.5
                },
                IntrovertToExtrovert = new PersonalityComponent
                {
                    Primary = 1.0,
                    Aspect = -0.5
                },
                ColdToEmpathetic = new PersonalityComponent
                {
                    Primary = 1.0,
                    Aspect = -0.5
                },
                UnflappableToAnxious = new PersonalityComponent
                {
                    Primary = 1.0,
                    Aspect = -0.5
                },
            },
            Description = "John's description goes here",
            IsHero = isHero
        }, new CompletionResponse
        {
            Id = Guid.NewGuid().ToString(),
            Prompt = "test",
            PromptIsToxic = false,
            PromptTokenCount = 123,
            Completion = "test completion",
            CompletionIsToxic = false,
            CompletionTokenCount = 456
        });
    }

    public async Task<(List<Character>, int)> GenerateAllCharacters(string userId, string plotId, string LogLineDescription, bool useTokens)
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