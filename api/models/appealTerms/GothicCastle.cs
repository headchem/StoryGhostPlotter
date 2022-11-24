using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class GothicCastle : IAppealTerm
{
    public string Id { get { return "GothicCastle"; } }
    public string Name { get { return "Gothic Castle"; } }
    public string PromptLabel { get { return "an ominous castle"; } }
    public string Description { get { return "Dark castles, helpless characters in distress, paranormal and atmospheric."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}