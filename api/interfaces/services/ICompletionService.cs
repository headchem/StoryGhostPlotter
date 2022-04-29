using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoryGhost.Models;
using StoryGhost.Models.Completions;

namespace StoryGhost.Interfaces;

public interface ICompletionService
{
    public Task<Dictionary<string, CompletionResponse>> GetLogLineDescriptionCompletion(Plot story, int keywordLogitBias);
    public Task<CompletionResponse> GetSequenceCompletion(string targetSequence, int maxTokens, double temperature, Plot story);
    public Task<CompletionResponse> GetCharacterCompletion(Character character);
    public Task<List<string>> GetTitles(List<string> genres, string logLineDescription);
    
    public Task<Plot> GenerateAllLogLine(List<string> genres);

    public Task<List<Character>> GenerateAllCharacters(string LogLineDescription, string ProblemTemplate, string DramaticQuestion);

    public Task<List<UserSequence>> GenerateAllSequences(Plot story, string upToTargetSequenceExclusive);
}