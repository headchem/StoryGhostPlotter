using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class ArchetypePersonalityTendencies
{
    public double ClosemindedToImaginativeTendency { get; set; }
    public double DisciplinedToSpontaneousTendency { get; set; }
    public double IntrovertToExtrovertTendency { get; set; }
    public double ColdToEmpatheticTendency { get; set; }
    public double UnflappableToAnxiousTendency { get; set; }
}