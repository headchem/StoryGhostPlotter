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
    public string Description { get { return "Codes and mystic symbols unlock ancient mysteries."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Thriller, GenresEnum.History, GenresEnum.Adventure }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Secrets }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}