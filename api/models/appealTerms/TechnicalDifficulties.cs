using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class TechnicalDifficulties : IAppealTerm
{
    public string Id { get { return "TechnicalDifficulties"; } }
    public string Name { get { return "Technical difficulties"; } }
    public string PromptLabel { get { return "technology impacting lives"; } }
    public string Description { get { return "For better or worse, technology impacts our lives."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}