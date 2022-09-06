using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Aloof : IEmotion
{
    public string Id { get { return "aloof"; } }
    public string Name { get { return "Aloof"; } }
    public string Description { get { return "Not friendly or forthcoming; cool and distant. Conspicuously uninvolved and uninterested, typically through distaste."; } }
    public List<string> Synonyms { get { return new List<string> { "distant", "detached", "unresponsive", "remote", "cold", "unapproachable", "" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0.1; } }
    public double TrustToDisgust { get { return 0.4; } }
    public double FearToAnger { get { return 0.6; } }
    public double SurpriseToAnticipation { get { return 0.6; } }

    public double AnxietyToConfidence { get { return -.3; } }
    public double BoredomToFascination { get { return -.5; } }
    public double FrustrationToEuphoria { get { return .1; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return .6; } }

    public double PleasureToDispleasure { get { return 0.62; } }
    public double ArousalToNonarousal { get { return 0.15; } }
    public double DominanceToSubmissiveness { get { return 0.4; } }

    public double InnerFocusToOutwardTarget { get { return 0.7; } }
}