using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SendInTheClones : IAppealTerm
{
    public string Id { get { return "SendInTheClones"; } }
    public string Name { get { return "Send in the clones"; } }
    public string Description { get { return "Cloning humans or transferring consciousness into machines has deep ethical implications."; } }
    public List<string> Genres { get { return new List<string> { "science fiction" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}