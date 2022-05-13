using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoryGhost.Models;
using StoryGhost.Models.Completions;

namespace StoryGhost.Interfaces;

public interface ICompletionService
{
    public Task<Dictionary<string, CompletionResponse>> GetLogLineDescriptionCompletion(string userId, Plot story, int keywordLogitBias);
    public Task<CompletionResponse> GetSequenceCompletion(string userId, string targetSequence, int maxTokens, double temperature, Plot story);
    public Task<CompletionResponse> GetCharacterCompletion(string userId, Character character);
    public Task<TitlesResponse> GetTitles(string userId, List<string> genres, string logLineDescription);
    
    ///<summary>Returns a tuple where the first value is the completed Plot object, and second tuple is the total Token cost.</summary>
    public Task<(Plot, int)> GenerateAllLogLine(string userId, List<string> genres);

    public Task<(List<Character>, int)> GenerateAllCharacters(string userId, string LogLineDescription, string ProblemTemplate, string DramaticQuestion);

    public Task<(List<UserSequence>, int)> GenerateAllSequences(string userId, Plot story, string upToTargetSequenceExclusive);
}