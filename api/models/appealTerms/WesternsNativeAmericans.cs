using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsNativeAmericans : IAppealTerm
{
    public string Id { get { return "WesternsNativeAmericans"; } }
    public string Name { get { return "Native Americans"; } }
    public string Description { get { return "The history of indigenous peoples is filled with trials and tribulations, particularly after white settlers arrived in North America. The indigenous characters in books and film have historically been portrayed in stereotypical terms, whether in the disparaging Tonto model or as the \"noble savage.\" The best tales about Native peoples are those told with respect and understanding for their cultures. Many deal with the depredations of the invading culture and the conflict between the two groups. Also included here are titles that deal with Indian captives. Some of the older titles unfortunately evidence the stereotypes found in the early days of the genre."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}