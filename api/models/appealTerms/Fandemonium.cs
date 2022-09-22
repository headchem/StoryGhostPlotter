using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class Fandemonium : IAppealTerm
{
    public string Id { get { return "Fandemonium"; } }
    public string Name { get { return "Fandemonium"; } }
    public string Description { get { return "In these stories, character immerse themselves in the pop culture surrounding their geeky interests, either in person or online."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "Aficionado" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}