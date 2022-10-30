using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ReturnOfMagic : IAppealTerm
{
    public string Id { get { return "ReturnOfMagic"; } }
    public string Name { get { return "Return of magic"; } }
    public string Description { get { return "Legend becomes reality as magic reenters the world."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}