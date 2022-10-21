using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class UnusualSleuths : IAppealTerm
{
    public string Id { get { return "UnusualSleuths"; } }
    public string Name { get { return "Unusual Sleuths"; } }
    public string Description { get { return "These amateurs leverage their unique backgrounds and professions to solve the case."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}