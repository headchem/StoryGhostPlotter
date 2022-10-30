using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class VampiresAmongUs : IAppealTerm
{
    public string Id { get { return "VampiresAmongUs"; } }
    public string Name { get { return "Vampires Among Us"; } }
    public string Description { get { return "These bloodsuckers are living amongst us."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror, GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Monsters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}