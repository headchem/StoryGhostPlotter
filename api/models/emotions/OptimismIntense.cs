using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class OptimismIntense : IEmotion
{
    public string Id { get { return "optimism-intense"; } }
    public string Name { get { return "Intense Optimism"; } }
    public string Description { get { return ""; } }
    public List<string> Synonyms { get { return new List<string> { "moderate hope" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return -1.0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 1.0 ; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.87; } }
    public double ArousalToNonarousal { get { return -.12; } }
    public double DominanceToSubmissiveness { get { return -.61; } }
	
	public double InnerFocusToOutwardTarget { get { return .7; } }
}