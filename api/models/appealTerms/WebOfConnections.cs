using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WebOfConnections : IAppealTerm
{
    public string Id { get { return "WebOfConnections"; } }
    public string Name { get { return "Web of connections"; } }
    public string PromptLabel { get { return "inanimate objects given voice to what they've witnessed"; } }
    public string Description { get { return "Inanimate objects are given a unique voice having witnessed much."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Fantasy, GenresEnum.Family }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.NarrativeDevices }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}