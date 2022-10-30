using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class PressPlayToStart : IAppealTerm
{
    public string Id { get { return "PressPlayToStart"; } }
    public string Name { get { return "Press play to start"; } }
    public string Description { get { return "Advanced technology allows these characters to plug in to a hyper-immersive world where there can be real-world consequences to actions in the simulation."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}