using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class EvilTransformations : IAppealTerm
{
    public string Id { get { return "EvilTransformations"; } }
    public string Name { get { return "Evil transformations"; } }
    public string Description { get { return "A normal, mild-mannered citizen transforms into something terrible."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}