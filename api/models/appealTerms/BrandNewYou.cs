using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class BrandNewYou : IAppealTerm
{
    public string Id { get { return "BrandNewYou"; } }
    public string Name { get { return "Brand new you"; } }
    public string PromptLabel { get { return "self-discovery"; } }
    public string Description { get { return "Personal changes lead to self-discovery."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}