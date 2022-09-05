using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Meditative : IEmotion
{
    public string Id { get { return "meditative"; } }
    public string Name { get { return "Meditative"; } }
    public string Description { get { return "Absorbed in meditation or considered thought."; } }
    public List<string> Synonyms { get { return new List<string> { "contemplative", "reflective", "pensive", "in-the-zone", "zoned-out", "in the groove", "deep in thought" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return -.3; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.1; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return -.1; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .1; } }
    public double HumiliationToPride { get { return .1; } }

    public double PleasureToDispleasure { get { return -.47; } }
    public double ArousalToNonarousal { get { return 0.71; } }
    public double DominanceToSubmissiveness { get { return 0.05; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}