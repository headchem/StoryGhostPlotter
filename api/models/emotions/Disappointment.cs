using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Disappointment : IEmotion
{
    public string Id { get { return "disappointment"; } }
    public string Name { get { return "Disappointment"; } }
    public string Description { get { return "The emotion felt when one's expectations are not met."; } }
    public List<string> Synonyms { get { return new List<string> { "dismay", "letdown" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return .5; } }
    public double TrustToDisgust { get { return 0.1; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.5; } }

    public double AnxietyToConfidence { get { return 0; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return -.7; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return 0.8; } }
    public double ArousalToNonarousal { get { return -.12; } }
    public double DominanceToSubmissiveness { get { return 0.47; } }

    public double InnerFocusToOutwardTarget { get { return 0.5; } }
}