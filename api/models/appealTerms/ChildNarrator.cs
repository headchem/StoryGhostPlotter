using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ChildNarrator : IAppealTerm
{
    public string Id { get { return "ChildNarrator"; } }
    public string Name { get { return "Child narrator"; } }
    public string PromptLabel { get { return "a child's perspective"; } }
    public string Description { get { return "These stories are told from a child's point of view."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.NarrativeDevices }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}