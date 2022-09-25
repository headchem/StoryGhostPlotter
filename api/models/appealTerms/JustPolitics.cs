using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class JustPolitics : IAppealTerm
{
    public string Id { get { return "JustPolitics"; } }
    public string Name { get { return "Just Politics"; } }
    public string Description { get { return "The pursuit of power gets ugly behind closed doors, while maintaining public trust is a must."; } }
    public List<string> Genres { get { return new List<string> { "thriller" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}