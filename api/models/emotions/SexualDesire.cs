using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class SexualDesire : IEmotion
{
    public string Id { get { return "sexual-desire"; } }
    public string Name { get { return "Sexual Desire"; } }
    public string Description { get { return "Emotional and motivational state characterized by an interest in sexual objects or activities, or by a drive to seek out sexuality."; } }
    public List<string> Synonyms { get { return new List<string> { "lust", "eroticism", "lechery", "desire" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return -.5; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -1.0; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return 1.0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return 1.0; } }
    public double TerrorToEnchantment { get { return 1.0; } }
    public double HumiliationToPride { get { return .2; } }

    public double PleasureToDispleasure { get { return -.51; } }
    public double ArousalToNonarousal { get { return -.75; } }
    public double DominanceToSubmissiveness { get { return -.37; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}