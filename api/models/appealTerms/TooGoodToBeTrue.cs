using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class TooGoodToBeTrue : IAppealTerm
{
    public string Id { get { return "TooGoodToBeTrue"; } }
    public string Name { get { return "Too good to be true"; } }
    public string Description { get { return "Something's not quite right, and these characters will tease it out, with dangerous implications."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Secrets, AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}