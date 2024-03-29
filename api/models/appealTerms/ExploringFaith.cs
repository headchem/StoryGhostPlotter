using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ExploringFaith : IAppealTerm
{
    public string Id { get { return "ExploringFaith"; } }
    public string Name { get { return "Exploring faith"; } }
    public string PromptLabel { get { return "exploring religious faith"; } }
    public string Description { get { return "Characters strive to balance religious faith with living their lives."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Drama }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}