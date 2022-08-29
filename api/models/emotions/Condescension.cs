using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Condescension : IEmotion
{
    public string Id { get { return "condescension"; } }
    public string Name { get { return "Condescension"; } }
    public string Description { get { return "The attitude or behavior of people who believe they are more intelligent or better than other people."; } }
    public List<string> Synonyms { get { return new List<string> { "disdain", "scorn" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0.7; } }
    public double FearToAnger { get { return 0.3; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .7; } }
    public double BoredomToFascination { get { return -.3; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return .5; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return .6; } }

    public double PleasureToDispleasure { get { return -.1; } }
    public double ArousalToNonarousal { get { return .26; } }
    public double DominanceToSubmissiveness { get { return -.16; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}