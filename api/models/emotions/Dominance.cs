using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Dominance : IEmotion
{
    public string Id { get { return "dominance"; } }
    public string Name { get { return "Dominance"; } }
    public string Description { get { return "Power and influence over others."; } }
    public List<string> Synonyms { get { return new List<string> { "supremacy", "superiority", "ascendancy", "preeminence" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social, EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return -.3; } }
    public double TrustToDisgust { get { return .3; } }
    public double FearToAnger { get { return 0.5; } }
    public double SurpriseToAnticipation { get { return .7; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .07; } }
    public double ArousalToNonarousal { get { return -.6; } }
    public double DominanceToSubmissiveness { get { return -.82; } }

    public double InnerFocusToOutwardTarget { get { return .6; } }
}