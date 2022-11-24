using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class JustGotOut : IAppealTerm
{
    public string Id { get { return "JustGotOut"; } }
    public string Name { get { return "Just got out"; } }
    public string PromptLabel { get { return "being back on the streets after doing time in prison"; } }
    public string Description { get { return "Back on the streets after doing time in prison."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}