using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class EvilAnimals : IAppealTerm
{
    public string Id { get { return "EvilAnimals"; } }
    public string Name { get { return "Evil animals"; } }
    public string Description { get { return "Animals develop a taste for human blood."; } }
    public List<string> Genres { get { return new List<string> { "horror" }; } }
    public List<string> Types { get { return new List<string> { "Monsters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}