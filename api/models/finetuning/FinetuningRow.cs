using System;
using System.Collections.Generic;

namespace StoryGhost.Models;

public class FinetuningRow
{
    public string SequenceName { get; set; }
    public string Prompt { get; set; }
    public string Completion { get; set; }
}