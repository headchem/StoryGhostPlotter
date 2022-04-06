using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class SequenceCompletions
{
    public List<string> StartCompletions { get; set; }
    public List<string> MiddleCompletions { get; set; }
    public List<string> EndingCompletions { get; set; }
}