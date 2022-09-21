using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class FaerieRealm : IAppealTerm
{
    public string Id { get { return "FaerieRealm"; } }
    public string Name { get { return "Faerie realm"; } }
    public string Description { get { return "Welcome to the land of the immortal fae."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}