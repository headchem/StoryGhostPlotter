using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class BoardingSchoolLife : IAppealTerm
{
    public string Id { get { return "BoardingSchoolLife"; } }
    public string Name { get { return "Boarding school life"; } }
    public string Description { get { return "It can get intense when you live with your classmates."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}