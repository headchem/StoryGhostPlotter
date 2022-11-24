using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LawsOfMagic : IAppealTerm
{
    public string Id { get { return "LawsOfMagic"; } }
    public string Name { get { return "Laws of magic"; } }
    public string PromptLabel { get { return "well defined magical systems"; } }
    public string Description { get { return "These magical systems follow their own strict internal logic"; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}