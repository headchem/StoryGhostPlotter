using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ComingOfAgeInAHarshWorld : IAppealTerm
{
    public string Id { get { return "ComingOfAgeInAHarshWorld"; } }
    public string Name { get { return "Coming Of Age In A Harsh World"; } }
    public string PromptLabel { get { return "coming of age in harsh world"; } }
    //public string Description { get { return "Traditionally in this genre, coming of age could be described as \"boy becomes man,\" but now protagonists of both genders are experiencing the trials and travails of the journey from childhood to adulthood on a harsh frontier."; } }
    public string Description { get { return "Experiencing the trials and travails of the journey from childhood to adulthood in a harsh world."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}