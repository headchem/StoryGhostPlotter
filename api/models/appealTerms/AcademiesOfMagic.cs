using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class AcademiesOfMagic : IAppealTerm
{
    public string Id { get { return "AcademiesOfMagic"; } }
    public string Name { get { return "Academies Of Magic"; } }
    public string Description { get { return "These are VERY special schools for the gifted."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Types { get { return new List<string> { "setting" }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        var keywordsStr = string.Join(", ", keywords);

        return $"In {eras.FirstOrDefault()} {locations.FirstOrDefault()}, students in a special school for the magically gifted must apply what they've learned outside of class, involving {keywordsStr}.";
    }

}