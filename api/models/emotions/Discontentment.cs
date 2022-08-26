using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Discontentment : IEmotion
{
    public string Id { get { return "discontentment"; } }
    public string Name { get { return "Discontentment"; } }
    public string Description { get { return "The condition of being dissatisfied with one's situation."; } }
    public List<string> Synonyms { get { return new List<string> { "disgruntled" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return .3; } }
    public double TrustToDisgust { get { return .3; } }
    public double FearToAnger { get { return .1; } }
    public double SurpriseToAnticipation { get { return -.3; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .52; } }
    public double ArousalToNonarousal { get { return -.06; } }
    public double DominanceToSubmissiveness { get { return .47; } }

    public double InnerFocusToOutwardTarget { get { return -.5; } }
}