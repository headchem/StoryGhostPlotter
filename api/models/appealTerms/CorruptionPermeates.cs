using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class CorruptionPermeates : IAppealTerm
{
    public string Id { get { return "CorruptionPermeates"; } }
    public string Name { get { return "Corruption Permeates"; } }
    public string Description { get { return "What hope does a White Knight detective have when all of society seems in on the crime?"; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}