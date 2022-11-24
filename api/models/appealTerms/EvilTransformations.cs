using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class EvilTransformations : IAppealTerm
{
    public string Id { get { return "EvilTransformations"; } }
    public string Name { get { return "Evil transformations"; } }
    public string PromptLabel { get { return "a normal person transforming into an evil monster"; } }
    public string Description { get { return "A normal, mild-mannered citizen transforms into a terrible monster."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Monsters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}