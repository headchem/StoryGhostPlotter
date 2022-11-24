using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class HiddenInPlainSight : IAppealTerm
{
    public string Id { get { return "HiddenInPlainSight"; } }
    public string Name { get { return "Hidden In Plain Sight"; } }
    public string PromptLabel { get { return "a criminal who remains hidden in plain sight"; } }
    public string Description { get { return "The least likely suspect did it, with clues that were right under our nose the entire time."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Secrets, AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}