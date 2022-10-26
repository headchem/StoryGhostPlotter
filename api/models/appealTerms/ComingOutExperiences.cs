using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ComingOutExperiences : IAppealTerm
{
    public string Id { get { return "ComingOutExperiences"; } }
    public string Name { get { return "Coming out experiences"; } }
    public string Description { get { return "Stories about being gay, lesbian, bisexual, transgender, intersex, or asexual."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Drama, GenresEnum.Romance, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { "Experiences" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}