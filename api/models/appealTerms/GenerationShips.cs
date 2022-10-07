using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class GenerationShips : IAppealTerm
{
    public string Id { get { return "GenerationShips"; } }
    public string Name { get { return "Generation ships"; } }
    public string Description { get { return "Self-sustaining spaceships support multiple generations of humans over hundreds of years while voyaging to distant stars."; } }
    public List<string> Genres { get { return new List<string> { "science fiction" }; } }
    public List<string> Types { get { return new List<string> { "Space and Time" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}