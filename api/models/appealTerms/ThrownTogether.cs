using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ThrownTogether : IAppealTerm
{
    public string Id { get { return "ThrownTogether"; } }
    public string Name { get { return "Thrown together"; } }
    public string PromptLabel { get { return "characters from different backgrounds being thrown together"; } }
    public string Description { get { return "Forging connections in unexpected ways when people of very different backgrounds are forced to interact."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.Relationships }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}