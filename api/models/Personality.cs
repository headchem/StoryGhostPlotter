using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class Personality
{
    public PersonalityComponent ClosemindedToImaginative { get; set; }
    public PersonalityComponent DisciplinedToSpontaneous { get; set; }
    public PersonalityComponent IntrovertToExtrovert { get; set; }
    public PersonalityComponent ColdToEmpathetic { get; set; }
    public PersonalityComponent UnflappableToAnxious { get; set; }
}