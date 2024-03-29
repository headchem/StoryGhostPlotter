using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Avarice : IEmotion
{
    public string Id { get { return "avarice"; } }
    public string Name { get { return "Avarice"; } }
    public string Description { get { return "Extreme greed for wealth or material gain."; } }
    public List<string> Synonyms { get { return new List<string> { "greed", "mercenariness", "rapacity", "covetousness" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0.4; } }
    public double FearToAnger { get { return 0.5; } }
    public double SurpriseToAnticipation { get { return 0.6; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return -.2; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return -.5; } }
    public double HumiliationToPride { get { return .7; } }

    public double PleasureToDispleasure { get { return .6; } }
    public double ArousalToNonarousal { get { return -.45; } }
    public double DominanceToSubmissiveness { get { return .3; } }

    public double InnerFocusToOutwardTarget { get { return .3; } }
}