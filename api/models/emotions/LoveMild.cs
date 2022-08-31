using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class LoveMild : IEmotion
{
    public string Id { get { return "love-mild"; } }
    public string Name { get { return "Mild Love"; } }
    public string Description { get { return "An feeling of affection. Like or enjoy. To hold dear"; } }
    public List<string> Synonyms { get { return new List<string> { "empathy", "caring", "cherish", "adore", "revere", "relish", "devotion", "romance" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Cathected }; } }

    public double JoyToSadness { get { return -.33; } }
    public double TrustToDisgust { get { return .33; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .5; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return .5; } }
    public double DispiritedToEncouraged { get { return .5; } }
    public double TerrorToEnchantment { get { return .5; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return -.5; } }
    public double ArousalToNonarousal { get { return -.2; } }
    public double DominanceToSubmissiveness { get { return -.2; } }
	
	public double InnerFocusToOutwardTarget { get { return 1.0; } }
}