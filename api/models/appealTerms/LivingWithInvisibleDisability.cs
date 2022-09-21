using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class LivingWithInvisibleDisability : IAppealTerm
{
    public string Id { get { return "LivingWithInvisibleDisability"; } }
    public string Name { get { return "Living with invisible disability"; } }
    public string Description { get { return "Some disabilities aren't easy to see, but still can make life challenging."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}