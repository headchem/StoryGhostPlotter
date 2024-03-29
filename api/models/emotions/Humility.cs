using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Humility : IEmotion
{
    public string Id { get { return "humility"; } }
    public string Name { get { return "Humility"; } }
    public string Description { get { return "The absence of any feelings of being better than others"; } }
    public List<string> Synonyms { get { return new List<string> { "demureness", "down-to-earth", "meekness", "modesty" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.SelfAppraisal }; } }

    public double JoyToSadness { get { return -.3; } }
    public double TrustToDisgust { get { return -.7; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .5; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return -.3; } }
    public double FrustrationToEuphoria { get { return .2; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return -.2; } }

    public double PleasureToDispleasure { get { return -.59; } }
    public double ArousalToNonarousal { get { return .63; } }
    public double DominanceToSubmissiveness { get { return .14; } }

    public double InnerFocusToOutwardTarget { get { return -.7; } }
}