using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Assemble : IAppealTerm
{
    public string Id { get { return "Assemble"; } }
    public string Name { get { return "Assemble"; } }
    public string PromptLabel { get { return "gathering a team to tackle a problem"; } }
    public string Description { get { return "To defeat the problem, everyone on the team's individual skills will be needed."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Adventure }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}