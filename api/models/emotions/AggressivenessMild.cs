using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class AggressivenessMild : IEmotion
{
    public string Id { get { return "aggressiveness-mild"; } }
    public string Name { get { return "Mild Aggressiveness"; } }
    public string Description { get { return "Hostile or violent behavior. Determination and forcefulness."; } }
    public List<string> Synonyms { get { return new List<string> { "pushy", "assertive", "enterprising" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated, EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return .33; } }
    public double SurpriseToAnticipation { get { return .33; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .25; } }
    public double ArousalToNonarousal { get { return -.25; } }
    public double DominanceToSubmissiveness { get { return -.1; } }
	
	public double InnerFocusToOutwardTarget { get { return .5; } }
}