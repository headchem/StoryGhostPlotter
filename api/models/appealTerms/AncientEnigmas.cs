using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class AncientEnigmas : IAppealTerm
{
    public string Id { get { return "AncientEnigmas"; } }
    public string Name { get { return "Ancient enigmas"; } }
    public string PromptLabel { get { return "investigating an ancient mystery"; } }
    public string Description { get { return "Codes, mystic symbols and family secrets unlock ancient mysteries."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Thriller, GenresEnum.History, GenresEnum.Adventure }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Secrets, AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}