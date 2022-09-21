using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class MeetTheFamily : IAppealTerm
{
    public string Id { get { return "MeetTheFamily"; } }
    public string Name { get { return "Meet the family"; } }
    public string Description { get { return "These stories are a family affair, starring a cast of parents, siblings, and other relatives."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}