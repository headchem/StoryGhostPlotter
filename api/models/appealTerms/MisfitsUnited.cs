using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MisfitsUnited : IAppealTerm
{
    public string Id { get { return "MisfitsUnited"; } }
    public string Name { get { return "Misfits united"; } }
    public string PromptLabel { get { return "misfits united against society"; } }
    public string Description { get { return "The characters in these stories feel like they don't fit in except with each other."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Relationships, AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}