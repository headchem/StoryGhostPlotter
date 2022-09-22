using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class BeCarefulWhatYouWishFor : IAppealTerm
{
    public string Id { get { return "BeCarefulWhatYouWishFor"; } }
    public string Name { get { return "Be careful what you wish for"; } }
    public string Description { get { return "Genies have to amuse themselves somehow."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}