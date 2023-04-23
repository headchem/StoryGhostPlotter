using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class HadIButKnown : IAppealTerm
{
    public string Id { get { return "HadIButKnown"; } }
    public string Name { get { return "Had I But Known"; } }
    public string PromptLabel { get { return "murders happening under the protagonist's nose"; } }
    public string Description { get { return "Characters wrestle with guilt as murders happen around them which they could have easily prevented had they noticed just a handful of clues."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}