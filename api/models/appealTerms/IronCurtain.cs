using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class IronCurtain : IAppealTerm
{
    public string Id { get { return "IronCurtain"; } }
    public string Name { get { return "Iron Curtain"; } }
    public string PromptLabel { get { return "the Cold War"; } }
    public string Description { get { return "The Cold War heats up in these stories about the world on the brink of nuclear annihilation."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Thriller, GenresEnum.History }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}