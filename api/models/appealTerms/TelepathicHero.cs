using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class TelepathicHero : IAppealTerm
{
    public string Id { get { return "TelepathicHero"; } }
    public string Name { get { return "Telepathic Hero"; } }
    public string Description { get { return "The protagonist has telepathy, which brings a sense of responsibility to prevent evil-doers from carrying out their plans, but also strains the hero's relationships as they hear everyone's secret thoughts."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}