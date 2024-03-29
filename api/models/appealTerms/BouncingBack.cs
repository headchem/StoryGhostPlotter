using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class BouncingBack : IAppealTerm
{
    public string Id { get { return "BouncingBack"; } }
    public string Name { get { return "Bouncing back"; } }
    public string PromptLabel { get { return "recovering from an intensely negative event"; } }
    public string Description { get { return "Bouncing back after a major setback."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}