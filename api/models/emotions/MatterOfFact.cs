using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class MatterOfFact : IEmotion
{
    public string Id { get { return "matter-of-fact"; } }
    public string Name { get { return "Matter of Fact"; } }
    public string Description { get { return "Unemotional and practical. The acceptance of something as just the way it is."; } }
    public List<string> Synonyms { get { return new List<string> { "unemotional", "practical", "down-to-earth", "sensible", "realistic", "rational" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated, EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0.0; } }
    public double TrustToDisgust { get { return -0.3; } }
    public double FearToAnger { get { return 0.0; } }
    public double SurpriseToAnticipation { get { return 0.3; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return -.1; } }
    public double FrustrationToEuphoria { get { return 0.0; } }
    public double DispiritedToEncouraged { get { return 0.0; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return .1; } }

    public double PleasureToDispleasure { get { return -.32; } }
    public double ArousalToNonarousal { get { return 0.08; } }
    public double DominanceToSubmissiveness { get { return -0.25; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}