using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Craving : IEmotion
{
    public string Id { get { return "craving"; } }
    public string Name { get { return "Craving"; } }
    public string Description { get { return "A strong wish to own or enjoy something."; } }
    public List<string> Synonyms { get { return new List<string> { "hankering", "lust", "urge", "yearning", "thirst" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return -.1; } }
    public double TrustToDisgust { get { return -.2; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .7; } }

    public double AnxietyToConfidence { get { return -.3; } }
    public double BoredomToFascination { get { return 1.0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return .5; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return -.14; } }
    public double ArousalToNonarousal { get { return -.27; } }
    public double DominanceToSubmissiveness { get { return -.37; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}