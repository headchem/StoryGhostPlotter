using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Longing : IEmotion
{
    public string Id { get { return "longing"; } }
    public string Name { get { return "Longing"; } }
    public string Description { get { return "A yearning desire. A strong wish for something"; } }
    public List<string> Synonyms { get { return new List<string> { "appetite", "craving", "drive", "passion", "urge" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Cathected }; } }

    public double JoyToSadness { get { return .5; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.3; } }

    public double AnxietyToConfidence { get { return .5; } }
    public double BoredomToFascination { get { return .8; } }
    public double FrustrationToEuphoria { get { return -.1; } }
    public double DispiritedToEncouraged { get { return -.7; } }
    public double TerrorToEnchantment { get { return .2; } }
    public double HumiliationToPride { get { return -.3; } }

    public double PleasureToDispleasure { get { return -.21; } }
    public double ArousalToNonarousal { get { return .13; } }
    public double DominanceToSubmissiveness { get { return -.12; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}