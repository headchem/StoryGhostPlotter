using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class HistoricalPrehistoric : IAppealTerm
{
    public string Id { get { return "HistoricalPrehistoric"; } }
    public string Name { get { return "Prehistoric"; } }
    public string Description { get { return "Readers want to know what life was like before our civilization and before there was a written record of how society lived. Often, the stories sweep through history, spanning generations. The dawn of humanity offers many venues for action-packed adventure and romantic encounters, and it gives room for speculations about what it means to be human, how one might survive in a \"primitive\" setting, and other philosophical musings. The settings, often drawn from archaeological and anthropological research, provide a distant and romantic arena for the action. However, even though the settings, costumes, and tools may be scientifically correct, the heroine or hero may exhibit traits and follow social mores belonging more in the late twentieth century than in prehistoric times."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.History }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}