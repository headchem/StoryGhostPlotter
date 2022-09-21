using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WartimeCrime : IAppealTerm
{
    public string Id { get { return "WartimeCrime"; } }
    public string Name { get { return "Wartime crime"; } }
    public string Description { get { return "The investigators in these stories must contend with criminals in a wartime setting."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}