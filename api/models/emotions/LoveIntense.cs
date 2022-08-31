using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class LoveIntense : IEmotion
{
    public string Id { get { return "love-intense"; } }
    public string Name { get { return "Intense Love"; } }
    public string Description { get { return "An intense feeling of deep affection. Like or enjoy very much. To hold dear"; } }
    public List<string> Synonyms { get { return new List<string> { "caring", "cherish", "adore", "revere", "relish", "devotion", "romance" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Cathected }; } }

    public double JoyToSadness { get { return -1.0; } }
    public double TrustToDisgust { get { return 1.0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return 1.0; } }
    public double BoredomToFascination { get { return 1.0; } }
    public double FrustrationToEuphoria { get { return 1.0; } }
    public double DispiritedToEncouraged { get { return 1.0; } }
    public double TerrorToEnchantment { get { return 1.0; } }
    public double HumiliationToPride { get { return .5; } }

    public double PleasureToDispleasure { get { return -.89; } }
    public double ArousalToNonarousal { get { return -.36; } }
    public double DominanceToSubmissiveness { get { return -.41; } }
	
	public double InnerFocusToOutwardTarget { get { return 1.0; } }
}