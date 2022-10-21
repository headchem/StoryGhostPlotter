using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ClosedSocieties : IAppealTerm
{
    public string Id { get { return "ClosedSocieties"; } }
    public string Name { get { return "Closed Societies"; } }
    public string Description { get { return "Upperclass murder in a small village, university, or manor (and its locked rooms). Country estates can hide secrets and bodies!"; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Categories { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}