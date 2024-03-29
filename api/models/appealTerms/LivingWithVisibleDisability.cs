using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LivingWithVisibleDisability : IAppealTerm
{
    public string Id { get { return "LivingWithVisibleDisability"; } }
    public string Name { get { return "Living with visible disability"; } }
    public string PromptLabel { get { return "living with a visible disability"; } }
    public string Description { get { return "Living in an able-bodied world isn't easy when your disability is on display."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Drama, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}