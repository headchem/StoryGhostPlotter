using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class TeenPregnancyAndParenting : IAppealTerm
{
    public string Id { get { return "TeenPregnancyAndParenting"; } }
    public string Name { get { return "Teen pregnancy and parenting"; } }
    public string Description { get { return "Teens confront the choices, changes, and challenges of pregnancy or becoming a parent."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}