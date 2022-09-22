using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SherlockPaws : IAppealTerm
{
    public string Id { get { return "SherlockPaws"; } }
    public string Name { get { return "Sherlock Paws"; } }
    public string Description { get { return "Animal detectives keeping their noses to the ground."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}