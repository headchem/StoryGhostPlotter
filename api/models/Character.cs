using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using StoryGhost.Models.Completions;

namespace StoryGhost.Models;

public class Character
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Archetype { get; set; }
    public string Description { get; set; }

    public List<CompletionResponse> AICompletions { get; set; }

    public Personality Personality { get; set; }

    public bool IsHero { get; set; }
}