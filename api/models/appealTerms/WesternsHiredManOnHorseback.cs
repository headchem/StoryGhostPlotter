using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WesternsHiredManOnHorseback : IAppealTerm
{
    public string Id { get { return "WesternsHiredManOnHorseback"; } }
    public string Name { get { return "Hired Man On Horseback"; } }
    public string Description { get { return "Cowboys are the quintessential understated Western heroes, but if they had spent their real lives like the cowboys in fiction do, ranching could never have survived."; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}