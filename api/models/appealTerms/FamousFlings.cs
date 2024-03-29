using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class FamousFlings : IAppealTerm
{
    public string Id { get { return "FamousFlings"; } }
    public string Name { get { return "Famous flings"; } }
    public string PromptLabel { get { return "love life in the public eye"; } }
    public string Description { get { return "These couples get caught in the limelight of the public eye."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Romance }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.Relationships }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}