using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class NovelsOfPlace : IAppealTerm
{
    public string Id { get { return "NovelsOfPlace"; } }
    public string Name { get { return "Novels of place"; } }
    public string Description { get { return "As much about the setting as the characters."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}