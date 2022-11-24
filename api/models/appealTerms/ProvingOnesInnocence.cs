using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ProvingOnesInnocence : IAppealTerm
{
    public string Id { get { return "ProvingOnesInnocence"; } }
    public string Name { get { return "Proving ones innocence"; } }
    public string PromptLabel { get { return "proving one's innocence"; } }
    public string Description { get { return "Sometimes the detective is also the primary suspect."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery, GenresEnum.Thriller }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}