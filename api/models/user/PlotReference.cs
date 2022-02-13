using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class PlotReference
{
    public string DataType { get { return "PlotReference"; } } // used to track type in Cosmos DB
    public string DataVersion { get { return "1.0"; } } // used to track schema version in Cosmos DB
    public string PlotId { get; set; }
    public string DisplayName { get; set; }
    public bool IsDeleted { get; set; }
}