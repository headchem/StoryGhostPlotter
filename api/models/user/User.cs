using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class User
{
    public List<PlotReference> PlotReferences { get; set; }
}