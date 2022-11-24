using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Gunslinger : IAppealTerm
{
    public string Id { get { return "Gunslinger"; } }
    public string Name { get { return "Gunslinger"; } }
    public string PromptLabel { get { return "a skilled gunslinger"; } }
    public string Description { get { return "What's the point of being the fastest gun in town if you don't use it?"; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}