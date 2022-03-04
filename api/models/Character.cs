using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class Character
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Archetype { get; set; }
    public string Description { get; set; }

    [JsonPropertyName("aiText")]
    public string AIText { get; set; }

    public Personality Personality { get; set; }
}