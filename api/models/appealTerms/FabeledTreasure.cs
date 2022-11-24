using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class FabeledTreasure : IAppealTerm
{
    public string Id { get { return "FabeledTreasure"; } }
    public string Name { get { return "Fabeled Treasure"; } }
    public string PromptLabel { get { return "famous treasure"; } }
    public string Description { get { return "These stories revolve around famous jewels, artwork, and other high society artifacts."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Adventure, GenresEnum.Crime, GenresEnum.Drama, GenresEnum.History, GenresEnum.Mystery, GenresEnum.Thriller }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}