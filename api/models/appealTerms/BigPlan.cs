using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class BigPlan : IAppealTerm
{
    public string Id { get { return "BigPlan"; } }
    public string Name { get { return "Big Plan"; } }
    public string Description { get { return "A leader cobbles together a team of specialists to execute a complicated plan. But something goes wrong and threatens to derail everything."; } }
    public List<string> Genres { get { return new List<string> { "thriller" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}