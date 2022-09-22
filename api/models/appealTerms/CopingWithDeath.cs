using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class CopingWithDeath : IAppealTerm
{
    public string Id { get { return "CopingWithDeath"; } }
    public string Name { get { return "Coping with death"; } }
    public string Description { get { return "Characters navigate grief following the loss of a loved one."; } }
    public List<string> Genres { get { return new List<string> { "drama", "family", "war" }; } }
    public List<string> Types { get { return new List<string> { "Life's Challenges" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}