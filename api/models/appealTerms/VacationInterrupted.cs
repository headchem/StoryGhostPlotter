using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class VacationInterrupted : IAppealTerm
{
    public string Id { get { return "VacationInterrupted"; } }
    public string Name { get { return "Vacation interrupted"; } }
    public string Description { get { return "A day at the beach turns deadly for these off-duty sleuths."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}