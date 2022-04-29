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

    public DummyCompletionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Dictionary<string, CompletionResponse>> GetLogLineDescriptionCompletion(Plot story, int keywordsLogitBias)
    {
        var prompt = "TODO log line desc prompt goes here...";

        var result = new CompletionResponse();

        result.Prompt = prompt;
        result.Completion = "AI Log Line Description completion goes here...";

        return new Dictionary<string, CompletionResponse> { ["finetuned"] = result };
    }

    public async Task<CompletionResponse> GetSequenceCompletion(string targetSequence, int maxTokens, double temperature, Plot story)
    {
        //var prompt = Factory.GetSequencePrompt(sequenceName, story);

        var promptSequenceText = CreateFinetuningDataset.GetSequenceTextUpTo(targetSequence, story);
        var prompt = Factory.GetSequencePartPrompt(targetSequence, story, promptSequenceText);

        var result = new CompletionResponse();

        result.Prompt = prompt;
        result.Completion = "AI SEQUENCE completion for " + targetSequence + " goes here...";

        return result;
    }

    public async Task<CompletionResponse> GetCharacterCompletion(Character character)
    {
        var prompt = "TODO character archetype prompt goes here...";

        var result = new CompletionResponse();

        result.Prompt = prompt;
        result.Completion = "AI CHARACTER completion goes here...";

        return result;
    }

    public async Task<List<string>> GetTitles(List<string> genres, string logLineDescription)
    {
        return new List<string>{
            "Title 1",
            "Title 2",
            "Title 3",
            "Title 4",
            "Title 5"
        };
    }

    public async Task<List<UserSequence>> GenerateAllSequences(Plot story, string upToTargetSequenceExclusive)
    {
        return new List<UserSequence>();
    }

    public async Task<Plot> GenerateAllLogLine(List<string> genres)
    {
        return new Plot
        {
            Keywords = new List<string> { "keyword 1", "keyword 2" },
            Title = "TESTING edit here...",
            LogLineDescription = "auto gen log line desc goes here",
            ProblemTemplate = Factory.GetProblemTemplates().OrderBy(x => Guid.NewGuid()).First().Name,
            DramaticQuestion = Factory.GetDramaticQuestions().OrderBy(x => Guid.NewGuid()).First().Name
        };
    }

    public async Task<List<Character>> GenerateAllCharacters(string LogLineDescription, string ProblemTemplate, string DramaticQuestion)
    {
        return new List<Character> {
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
        };
    }

}