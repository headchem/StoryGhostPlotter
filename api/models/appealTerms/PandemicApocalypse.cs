using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class PandemicApocalypse : IAppealTerm
{
    public string Id { get { return "PandemicApocalypse"; } }
    public string Name { get { return "Pandemic apocalypse"; } }
    public string Description { get { return "Both infected and uninfected must struggle to survive."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}