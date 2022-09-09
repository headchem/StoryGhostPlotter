using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Industrious : IEmotion
{
    public string Id { get { return "industrious"; } }
    public string Name { get { return "Industrious"; } }
    public string Description { get { return "Constantly, regularly, or habitually active or occupied. Diligent and hard-working."; } }
    public List<string> Synonyms { get { return new List<string> { "working", "diligent", "working", "focused", "studying", "persistent" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.1; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.5; } }

    public double AnxietyToConfidence { get { return .1; } }
    public double BoredomToFascination { get { return .1; } }
    public double FrustrationToEuphoria { get { return .1; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return -.48; } }
    public double ArousalToNonarousal { get { return .04; } }
    public double DominanceToSubmissiveness { get { return -.55; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}