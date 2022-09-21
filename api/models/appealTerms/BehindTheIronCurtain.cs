using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class BehindTheIronCurtain : IAppealTerm
{
    public string Id { get { return "BehindTheIronCurtain"; } }
    public string Name { get { return "Behind the Iron Curtain"; } }
    public string Description { get { return "The Cold War heats up in these spy stories."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}