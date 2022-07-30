using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using StoryGhost.Models.Completions;

namespace StoryGhost.Models;

public class SceneSummaryDTO
{
    public string PlotId { get; set; }

    public string Full { get; set; }
    
    public List<string> CharacterNames { get; set; }
}