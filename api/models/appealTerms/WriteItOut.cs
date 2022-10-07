using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WriteItOut : IAppealTerm
{
    public string Id { get { return "WriteItOut"; } }
    public string Name { get { return "Write it out"; } }
    public string Description { get { return "Characters find their voice in the written word."; } }
    public List<string> Genres { get { return new List<string> { "crime", "drama", "horror", "mystery", "war" }; } }
    public List<string> Types { get { return new List<string> { "Personal Development" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}