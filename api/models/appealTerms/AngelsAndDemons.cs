using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class AngelsAndDemons : IAppealTerm
{
    public string Id { get { return "AngelsAndDemons"; } }
    public string Name { get { return "Angels And Demons"; } }
    public string Description { get { return "The story dips in and out of Heaven and Hell as real places, with the mortal realm as the halfway point battleground."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}