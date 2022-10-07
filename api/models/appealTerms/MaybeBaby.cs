using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class MaybeBaby : IAppealTerm
{
    public string Id { get { return "MaybeBaby"; } }
    public string Name { get { return "Maybe baby"; } }
    public string Description { get { return "Adoptions, guardianships, and other non-traditional ways of starting a family."; } }
    public List<string> Genres { get { return new List<string> { "adventure", "comedy", "drama", "family", "romance" }; } }
    public List<string> Types { get { return new List<string> { "Family and Relationships" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}