using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class UntrustedMind : IAppealTerm
{
    public string Id { get { return "UntrustedMind"; } }
    public string Name { get { return "Untrusted Mind"; } }
    public string PromptLabel { get { return "being unable to trust one's own mind"; } }
    public string Description { get { return "These characters can't trust their own minds."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { "psychosis", "hallucination", "memory loss" }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}