using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Immortal : IAppealTerm
{
    public string Id { get { return "Immortal"; } }
    public string Name { get { return "Immortal"; } }
    public string Description { get { return "These characters are functionally immortal - is it a blessing or a curse?"; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy, GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}