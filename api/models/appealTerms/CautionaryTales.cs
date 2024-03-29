using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class CautionaryTales : IAppealTerm
{
    public string Id { get { return "CautionaryTales"; } }
    public string Name { get { return "Cautionary tales"; } }
    public string PromptLabel { get { return "negative consequences of an action"; } }
    public string Description { get { return "Consequences can be harsh."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}