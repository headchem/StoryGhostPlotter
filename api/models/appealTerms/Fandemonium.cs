using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Fandemonium : IAppealTerm
{
    public string Id { get { return "Fandemonium"; } }
    public string Name { get { return "Fandemonium"; } }
    public string PromptLabel { get { return "pop culture"; } }
    public string Description { get { return "In these stories, characters get immersed in pop culture icons and activities."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Drama, GenresEnum.Romance, GenresEnum.Music, GenresEnum.Sports }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}