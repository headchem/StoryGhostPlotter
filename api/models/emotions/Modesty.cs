using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Modesty : IEmotion
{
    public string Id { get { return "modesty"; } }
    public string Name { get { return "Modesty"; } }
    public string Description { get { return "The absence of any feelings of being better than others. The quality or state of being unassuming or moderate in the estimation of one's abilities. Behavior, manner, or appearance intended to avoid impropriety or indecency."; } }
    public List<string> Synonyms { get { return new List<string> { "self-effacement", "humility", "moderation", "unpretentious", "demure", "down-to-earth" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.3; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .2; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.54; } }
    public double ArousalToNonarousal { get { return .63; } }
    public double DominanceToSubmissiveness { get { return .09; } }

    public double InnerFocusToOutwardTarget { get { return -.5; } }
}