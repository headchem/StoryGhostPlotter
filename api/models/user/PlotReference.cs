using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class PlotReference
{
    public string PlotId { get; set; }
    public string DisplayName {get; set;}
}