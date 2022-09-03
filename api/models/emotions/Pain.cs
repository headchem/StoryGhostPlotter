using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Pain : IEmotion
{
    public string Id { get { return "pain"; } }
    public string Name { get { return "Pain"; } }
    public string Description { get { return "Physical suffering or discomfort caused by illness or injury."; } }
    public List<string> Synonyms { get { return new List<string> { "suffering", "agony", "affliction", "torture", "torment", "discomfort", "hurt", "ache", "throb" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return .7; } }
    public double TrustToDisgust { get { return .7; } }
    public double FearToAnger { get { return -.7; } }
    public double SurpriseToAnticipation { get { return -1.0; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return -.7; } }
    public double TerrorToEnchantment { get { return -.7; } }
    public double HumiliationToPride { get { return -.3; } }

    public double PleasureToDispleasure { get { return .81; } }
    public double ArousalToNonarousal { get { return -.42; } }
    public double DominanceToSubmissiveness { get { return .3; } }

    public double InnerFocusToOutwardTarget { get { return -.8; } }
}