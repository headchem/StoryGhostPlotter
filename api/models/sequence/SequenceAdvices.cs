using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class SequenceAdvices
{
    public AdviceSequence Events { get; set; }
    public AdviceSequence Context { get; set; }
    
}