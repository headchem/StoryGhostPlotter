using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class DarkLord : IAppealTerm
{
    public string Id { get { return "DarkLord"; } }
    public string Name { get { return "Dark lord"; } }
    public string PromptLabel { get { return "a dark lord leading a nefarious army"; } }
    public string Description { get { return "These evil lords and ladies are assembling armies of darkness to conquer the world."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}