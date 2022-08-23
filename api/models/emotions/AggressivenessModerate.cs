using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class AggressivenessModerate : IEmotion
{
    public string Id { get { return "aggressiveness-moderate"; } }
    public string Name { get { return "Moderate Aggressiveness"; } }
    public string Description { get { return ""; } }
    public List<string> Synonyms { get { return new List<string> { "demanding" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated, EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return .66; } }
    public double SurpriseToAnticipation { get { return .66; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .45; } }
    public double ArousalToNonarousal { get { return -.5; } }
    public double DominanceToSubmissiveness { get { return -.2; } }
	
	public double InnerFocusToOutwardTarget { get { return .7; } }
}