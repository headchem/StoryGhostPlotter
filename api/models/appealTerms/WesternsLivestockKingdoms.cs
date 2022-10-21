using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsLivestockKingdoms : IAppealTerm
{
    public string Id { get { return "WesternsLivestockKingdoms"; } }
    public string Name { get { return "Livestock Kingdoms"; } }
    public string Description { get { return "Driving cattle to a railhead provides the opportunity for adventures involving problems caused by both nature (stampedes, lightning, floods) and humans (rustlers, outlaws, Indians). -- Although railroad barons dominated the country in the West, individuals tried to build their own fiefdoms based on huge ranges full of cattle. -- The battle for free range and to keep the West unfenced provides a scenario rife with possibilities. -- Cattlemen were not the only ones who moved West looking for wide-open land, leading to bitter conflicts between those who raised sheep and those who raised cattle. -- In just a few years, abundant herds of millions of buffalo were decimated almost to the point of extinction. The best of those engaged in this short-lived but lucrative trade were called runners instead of hunters, as they had to keep on the move because their prey was always roaming."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Animals, AppealTermsCategoryEnum.OccupationsAndEnterprise }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}