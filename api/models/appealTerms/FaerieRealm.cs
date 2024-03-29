using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class FaerieRealm : IAppealTerm
{
    public string Id { get { return "FaerieRealm"; } }
    public string Name { get { return "Faerie realm"; } }
    public string PromptLabel { get { return "faeries"; } }
    public string Description { get { return "Welcome to the land of the immortal fae."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}