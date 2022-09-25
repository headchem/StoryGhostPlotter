using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class TimesAreChanging : IAppealTerm
{
    public string Id { get { return "TimesAreChanging"; } }
    public string Name { get { return "Times Are Changing"; } }
    public string Description { get { return "The march of civilization and technology encroach on the traditional way of life. Some flee it, others fight."; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}