using System;
using System.Collections.Generic;
using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface IAppealTerm
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public List<string> Genres { get; }
    public List<string> Types { get; }

    ///<summary>Returns an example log line based on common patterns for this specific Appeal Term based on Top_10000_Movies.xlsx</summary>
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords);
}