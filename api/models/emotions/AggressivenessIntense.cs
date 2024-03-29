using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class AggressivenessIntense : IEmotion
{
    public string Id { get { return "aggressiveness-intense"; } }
    public string Name { get { return "Intense Aggressiveness"; } }
    public string Description { get { return "Hostile or violent behavior. Determination and forcefulness."; } }
    public List<string> Synonyms { get { return new List<string> { "fierce", "ambitious", "in-your-face", "threatening" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated, EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 1.0; } }
    public double SurpriseToAnticipation { get { return 1.0; } }

    public double AnxietyToConfidence { get { return .7; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return -.3; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .72; } }
    public double ArousalToNonarousal { get { return -.87; } }
    public double DominanceToSubmissiveness { get { return -.34; } }
	
	public double InnerFocusToOutwardTarget { get { return 1.0; } }
}