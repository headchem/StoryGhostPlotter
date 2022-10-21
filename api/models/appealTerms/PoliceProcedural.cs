using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class PoliceProcedural : IAppealTerm
{
    public string Id { get { return "PoliceProcedural"; } }
    public string Name { get { return "Police Procedural"; } }
    public string Description { get { return "A team of professionals use every tool available to tease out clues, while navigating their own interpersonal drama."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}