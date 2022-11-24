using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MagicGoesAway : IAppealTerm
{
    public string Id { get { return "MagicGoesAway"; } }
    public string Name { get { return "Magic goes away"; } }
    public string PromptLabel { get { return "those accustomed to magic finding their power has vanished"; } }
    public string Description { get { return "Those accustomed to magic suddenly find themselves without."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}