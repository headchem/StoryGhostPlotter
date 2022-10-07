using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class AcademiesOfMagic : IAppealTerm
{
    public string Id { get { return "AcademiesOfMagic"; } }
    public string Name { get { return "Academies of magic"; } }
    public string Description { get { return "These are special schools for the magically gifted."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}