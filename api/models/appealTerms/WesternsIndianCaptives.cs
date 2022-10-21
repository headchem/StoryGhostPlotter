using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsIndianCaptives : IAppealTerm
{
    public string Id { get { return "WesternsIndianCaptives"; } }
    public string Name { get { return "Indian Captives"; } }
    public string Description { get { return "Popular since colonial times, these tales about individuals captured by Indians who are often adopted into the tribes and about those who search for them have a great appeal. The idea of living inside another culture shows readers a view from an angle that cannot be seen by those completely outside a specific culture or by those on the outside, looking in but able only to experience the culture as an outsider. A captive's view often provides a way of seeing the daily routines of a culture."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}