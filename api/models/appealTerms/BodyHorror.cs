using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class BodyHorror : IAppealTerm
{
    public string Id { get { return "BodyHorror"; } }
    public string Name { get { return "Body horror"; } }
    public string Description { get { return "Reader beware horrible things can happen to the human body."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}