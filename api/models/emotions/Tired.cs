using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Tired : IEmotion
{
    public string Id { get { return "tired"; } }
    public string Name { get { return "Tired"; } }
    public string Description { get { return "In need of sleep or rest."; } }
    public List<string> Synonyms { get { return new List<string> { "tired", "exhausted", "weary", "worn out", "fatigued", "sleepy" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return -.2; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.2; } }

    public double AnxietyToConfidence { get { return 0; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -.1; } }
    public double TerrorToEnchantment { get { return .1; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return 0.55; } }
    public double ArousalToNonarousal { get { return .32; } }
    public double DominanceToSubmissiveness { get { return .58; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}