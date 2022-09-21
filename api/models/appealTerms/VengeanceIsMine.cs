using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class VengeanceIsMine : IAppealTerm
{
    public string Id { get { return "VengeanceIsMine"; } }
    public string Name { get { return "Vengeance is mine"; } }
    public string Description { get { return "Hell hath no fury like a character scorned."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}