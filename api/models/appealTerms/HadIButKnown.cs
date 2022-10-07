using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class HadIButKnown : IAppealTerm
{
    public string Id { get { return "HadIButKnown"; } }
    public string Name { get { return "Had I But Known"; } }
    public string Description { get { return "Characters wrestle with guilt as murders happen around them which they could have easily prevented had they noticed just a handful of clues. It's a race to find the killer before the killer ties up loose ends with these characters at the center of it all."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}