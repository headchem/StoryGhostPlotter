using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Acceptance : IEmotion
{
    public string Id { get { return "acceptance"; } }
    public string Name { get { return "Acceptance"; } }
    public string Description { get { return "The action or process of being received as adequate or suitable, typically to be admitted into a group. The action of consenting to receive or undertake something offered."; } }
    public List<string> Synonyms { get { return new List<string> { "welcoming", "favorable reception", "embrace" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return -.33; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.67; } }
    public double ArousalToNonarousal { get { return .36; } }
    public double DominanceToSubmissiveness { get { return -.28; } }

    public double InnerFocusToOutwardTarget { get { return .33; } }
}