using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class EvilCorporations : IAppealTerm
{
    public string Id { get { return "EvilCorporations"; } }
    public string Name { get { return "Evil corporations"; } }
    public string Description { get { return "Soylent Green, Skynet, SPECTRE — well, we all gotta do something that pays the rent."; } }
    public List<string> Genres { get { return new List<string> { "science fiction" }; } }
    public List<string> Types { get { return new List<string> { "Apocalyptic and Dystopian" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}