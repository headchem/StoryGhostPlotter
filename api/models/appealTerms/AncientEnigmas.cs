using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class AncientEnigmas : IAppealTerm
{
    public string Id { get { return "AncientEnigmas"; } }
    public string Name { get { return "Ancient enigmas"; } }
    public string Description { get { return "Codes and mystic symbols unlock ancient mysteries."; } }
    public List<string> Genres { get { return new List<string> { "thriller", "history" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}