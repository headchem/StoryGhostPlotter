using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Habituation : IEmotion
{
    public string Id { get { return "habituation"; } }
    public string Name { get { return "Habituation"; } }
    public string Description { get { return "The diminishing of a physiological or emotional response to a frequently repeated stimulus."; } }
    public List<string> Synonyms { get { return new List<string> { "dependence", "addiction", "tolerance" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return -.1; } }
    public double TrustToDisgust { get { return -.5; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.17; } }
    public double ArousalToNonarousal { get { return .49; } }
    public double DominanceToSubmissiveness { get { return -.11; } }

    public double InnerFocusToOutwardTarget { get { return 0; } }
}