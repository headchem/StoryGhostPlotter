using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class DontGoInThere : IAppealTerm
{
    public string Id { get { return "DontGoInThere"; } }
    public string Name { get { return "Dont go in there"; } }
    public string Description { get { return "It takes more guts than brains to visit these creepy spots."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}