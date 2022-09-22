using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ClimateChangeApocalypse : IAppealTerm
{
    public string Id { get { return "ClimateChangeApocalypse"; } }
    public string Name { get { return "Climate change apocalypse"; } }
    public string Description { get { return "Weathering devastating environmental change."; } }
    public List<string> Genres { get { return new List<string> { "science fiction" }; } }
    public List<string> Types { get { return new List<string> { "Apocalyptic and Dystopian" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}