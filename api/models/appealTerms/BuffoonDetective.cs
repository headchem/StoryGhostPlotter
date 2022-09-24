using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class BuffoonDetective : IAppealTerm
{
    public string Id { get { return "BuffoonDetective"; } }
    public string Name { get { return "Buffoon Detective"; } }
    public string Description { get { return "This detective follows all the clues to a spectacularly wrong conclusion, but incredibly manages to bring the bad guys to justice anyways."; } }
    public List<string> Genres { get { return new List<string> { "mystery", "comedy" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}