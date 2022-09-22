using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class MusicMakers : IAppealTerm
{
    public string Id { get { return "MusicMakers"; } }
    public string Name { get { return "Music makers"; } }
    public string Description { get { return "Sounds come together to make music, and these stories come to life."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "Personal Development" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}