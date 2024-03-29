using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class DealingWithMentalIllness : IAppealTerm
{
    public string Id { get { return "DealingWithMentalIllness"; } }
    public string Name { get { return "Dealing with mental illness"; } }
    public string PromptLabel { get { return "coping with mental illness"; } }
    public string Description { get { return "Maladies of the mind can be the source of our greatest challenges."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}