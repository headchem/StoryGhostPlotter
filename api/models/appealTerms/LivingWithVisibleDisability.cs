using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LivingWithVisibleDisability : IAppealTerm
{
    public string Id { get { return "LivingWithVisibleDisability"; } }
    public string Name { get { return "Living with visible disability"; } }
    public string Description { get { return "Living in an able-bodied world isn't easy when your disability is on display."; } }
    public List<string> Genres { get { return new List<string> { "drama", "urban" }; } }
    public List<string> Categories { get { return new List<string> { "Life's Challenges" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}