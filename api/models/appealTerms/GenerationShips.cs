using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class GenerationShips : IAppealTerm
{
    public string Id { get { return "GenerationShips"; } }
    public string Name { get { return "Generation ships"; } }
    public string PromptLabel { get { return "spaceships that support generations of humans over countless years"; } }
    public string Description { get { return "Self-sustaining spaceships support multiple generations of humans over countless years while voyaging to distant stars."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.SpaceAndTime }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}