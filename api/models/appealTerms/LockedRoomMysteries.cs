using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LockedRoomMysteries : IAppealTerm
{
    public string Id { get { return "LockedRoomMysteries"; } }
    public string Name { get { return "Locked room mysteries"; } }
    public string PromptLabel { get { return "an isolated crime scene with a small suspect list"; } }
    public string Description { get { return "The crime scene is isolated, and the suspect list is small."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.Secrets, AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}