using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class HiddenHeritage : IAppealTerm
{
    public string Id { get { return "HiddenHeritage"; } }
    public string Name { get { return "Hidden heritage"; } }
    public string Description { get { return "There's more to these characters than meets the eye."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}