using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Dissatisfied : IEmotion
{
    public string Id { get { return "dissatisfied"; } }
    public string Name { get { return "Dissatisfied"; } }
    public string Description { get { return ""; } }
    public List<string> Synonyms { get { return new List<string> { }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0.3; } }
    public double TrustToDisgust { get { return 0.2; } }
    public double FearToAnger { get { return 0.1; } }
    public double SurpriseToAnticipation { get { return -.3; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return 0.84; } }
    public double ArousalToNonarousal { get { return -.22; } }
    public double DominanceToSubmissiveness { get { return .51; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}