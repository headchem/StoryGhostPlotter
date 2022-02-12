using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class User
{

    public string Id { get; set; }

    public string DisplayName { get; set; }

    public List<PlotReference> PlotReferences { get; set; }
}