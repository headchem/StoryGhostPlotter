using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SadSmallTowns : IAppealTerm
{
    public string Id { get { return "SadSmallTowns"; } }
    public string Name { get { return "Sad small towns"; } }
    public string Description { get { return "The kind of place most folks leave, if they can."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}