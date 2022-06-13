using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoryGhost.Models;
using StoryGhost.Models.Completions;

namespace StoryGhost.Interfaces;

public interface ICompletionService
{
    public Task<CompletionResponse> GetLogLineDescriptionCompletion(string userId, double temperature, Plot story, int keywordLogitBias, bool bypassTokenCheck);

    public Task<CompletionResponse> GetBlurbCompletion(string userId, string targetSequence, int maxTokens, double temperature, Plot story, bool bypassTokenCheck);
    public Task<CompletionResponse> GetExpandedSummaryCompletion(string userId, string targetSequence, int maxTokens, double temperature, Plot story, bool bypassTokenCheck);
    public Task<CompletionResponse> GetFullCompletion(string userId, string targetSequence, int maxTokens, double temperature, Plot story, bool bypassTokenCheck);

    public Task<CompletionResponse> GetCharacterCompletion(string userId, string plotId, double temperature, Character character, bool bypassTokenCheck);
    public Task<TitlesResponse> GetTitles(string userId, string plotId, List<string> genres, string logLineDescription, bool bypassTokenCheck);

    ///<summary>Returns a tuple where the first value is the completed Plot object, and second tuple is the total Token cost.</summary>
    public Task<(Plot, int)> GenerateAllLogLine(string userId, string plotId, List<string> genres);

    public Task<(Character, CompletionResponse)> GenerateCharacter(string userId, string plotId, Character curCharacter, List<Character> existingCharacters);

    public Task<(List<Character>, int)> GenerateAllCharacters(string userId, string plotId, string LogLineDescription);

    public Task<(List<UserSequence>, int)> GenerateAllSequences(string userId, Plot story, string upToTargetSequenceExclusive);
}