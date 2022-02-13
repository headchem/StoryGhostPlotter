using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class User
{

    public string DataType { get { return "User"; } } // used to track type in Cosmos DB
    public string DataVersion { get { return "1.0"; } } // used to track schema version in Cosmos DB

    public string Id { get; set; }

    public string DisplayName { get; set; }

    /// <summary>UTC date the user was first created.</summary>
    public DateTime Created { get; set; }

    /// <summary>UTC date any user property, including adding (but not modifying) new PlotReferences, was last modified.</summary>
    public DateTime Modified { get; set; }

    public List<PlotReference> PlotReferences { get; set; }
}