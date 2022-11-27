using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class FirstContact : IAppealTerm
{
    public string Id { get { return "FirstContact"; } }
    public string Name { get { return "First contact"; } }
    public string PromptLabel { get { return "aliens and humanity making first contact"; } }
    public string Description { get { return "We're not alone in the universe after all as aliens and humanity make contact with each other."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.AliensAndRobots }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}