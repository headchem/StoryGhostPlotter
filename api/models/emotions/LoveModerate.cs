using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class LoveModerate : IEmotion
{
    public string Id { get { return "love-moderate"; } }
    public string Name { get { return "Moderate Love"; } }
    public string Description { get { return "An feeling of deep affection. Like or enjoy very much. To hold dear"; } }
    public List<string> Synonyms { get { return new List<string> { "caring", "cherish", "adore", "revere", "relish", "devotion", "romance" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Cathected }; } }

    public double JoyToSadness { get { return -.66; } }
    public double TrustToDisgust { get { return .66; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.7; } }
    public double ArousalToNonarousal { get { return -.28; } }
    public double DominanceToSubmissiveness { get { return -.3; } }
	
	public double InnerFocusToOutwardTarget { get { return 1.0; } }
}