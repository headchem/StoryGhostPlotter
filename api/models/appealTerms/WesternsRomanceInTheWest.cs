using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WesternsRomanceInTheWest : IAppealTerm
{
    public string Id { get { return "WesternsRomanceInTheWest"; } }
    public string Name { get { return "Romance In The West"; } }
    public string Description { get { return "Wide-open landscapes, towering mountain ranges, and vivid sunsets make the West a natural setting for romantic fiction. The strong individuals who settled the area also make for engaging romantic leads. The Western setting and heroes have become extremely popular in romance; the sheer abundance of cowboys in romance publishing makes it appear that all American men are cowboys (or at least the good-looking, romantic ones)."; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}