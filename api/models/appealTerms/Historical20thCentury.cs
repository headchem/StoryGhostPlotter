using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Historical20thCentury : IAppealTerm
{
    public string Id { get { return "Historical20thCentury"; } }
    public string Name { get { return "20th Century"; } }
    public string PromptLabel { get { return "the 1900s"; } }
    public string Description { get { return "The first half of the twentieth century was filled with notable points in history: the two world wars, the Great Depression, Prohibition, and women's suffrage."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.History }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}