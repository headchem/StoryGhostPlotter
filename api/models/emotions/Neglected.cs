using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Neglected : IEmotion
{
    public string Id { get { return "neglected"; } }
    public string Name { get { return "Neglected"; } }
    public string Description { get { return ""; } }
    public List<string> Synonyms { get { return new List<string> { }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social, EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0.8; } }
    public double TrustToDisgust { get { return 0.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.2; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .67; } }
    public double ArousalToNonarousal { get { return .08; } }
    public double DominanceToSubmissiveness { get { return .63; } }

    public double InnerFocusToOutwardTarget { get { return -.3; } }
}