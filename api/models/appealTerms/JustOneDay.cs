using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class JustOneDay : IAppealTerm
{
    public string Id { get { return "JustOneDay"; } }
    public string Name { get { return "Just one day"; } }
    public string PromptLabel { get { return "all the events that take place in just 24 hours"; } }
    public string Description { get { return "A lot can happen in just 24 hours!"; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.NarrativeDevices }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}