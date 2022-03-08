using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class AdviceComponentsWrapper
{
    public AdviceComponents Events { get; set; }
    public AdviceComponents Context { get; set; }


}