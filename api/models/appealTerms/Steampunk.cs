using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class Steampunk : IAppealTerm
{
    public string Id { get { return "Steampunk"; } }
    public string Name { get { return "Steampunk"; } }
    public string Description { get { return "Combining Victorian and Western time frames. A melting pot of Science Fiction, Fantasy and Romance."; } }
    public List<string> Genres { get { return new List<string> { "science fiction", "fantasy", "romance" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}