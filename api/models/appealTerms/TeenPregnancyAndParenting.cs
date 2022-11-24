using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class TeenPregnancyAndParenting : IAppealTerm
{
    public string Id { get { return "TeenPregnancyAndParenting"; } }
    public string Name { get { return "Teen pregnancy and parenting"; } }
    public string PromptLabel { get { return "teen pregnancy and parenting"; } }
    public string Description { get { return "Teens confront the changes, stigmas and challenges of pregnancy or parenthood."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Drama, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.LifeChallenges, AppealTermsCategoryEnum.Secrets }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}