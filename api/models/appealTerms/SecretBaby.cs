using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SecretBaby : IAppealTerm
{
    public string Id { get { return "SecretBaby"; } }
    public string Name { get { return "Secret baby"; } }
    public string Description { get { return "Revealing a secret love child helps these couples reunite."; } }
    public List<string> Genres { get { return new List<string> { "romance" }; } }
    public List<string> Types { get { return new List<string> { "Baby On Board" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}