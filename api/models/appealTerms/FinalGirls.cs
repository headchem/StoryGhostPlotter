using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class FinalGirls : IAppealTerm
{
    public string Id { get { return "FinalGirls"; } }
    public string Name { get { return "Final girls"; } }
    public string Description { get { return "The lone female survivors of a horrific event."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror, GenresEnum.Fantasy, GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}