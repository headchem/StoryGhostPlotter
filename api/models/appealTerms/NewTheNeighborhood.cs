using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class NewTheNeighborhood : IAppealTerm
{
    public string Id { get { return "NewTheNeighborhood"; } }
    public string Name { get { return "New the neighborhood"; } }
    public string Description { get { return "It’s tough being the new kid on the block."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}