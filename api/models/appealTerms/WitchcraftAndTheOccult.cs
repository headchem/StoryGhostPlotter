using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WitchcraftAndTheOccult : IAppealTerm
{
    public string Id { get { return "WitchcraftAndTheOccult"; } }
    public string Name { get { return "Witchcraft and the occult"; } }
    public string Description { get { return "Sinister spell-casting begets supernatural horror."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}