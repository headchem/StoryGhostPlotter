using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class IdillicTreachery : IAppealTerm
{
    public string Id { get { return "IdillicTreachery"; } }
    public string Name { get { return "Idillic Treachery"; } }
    public string Description { get { return "The landscape is romanticized but also treacherous. Survival has its ups and downs."; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}