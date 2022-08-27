using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class OptimismModerate : IEmotion
{
    public string Id { get { return "optimism-moderate"; } }
    public string Name { get { return "Moderate Optimism"; } }
    public string Description { get { return "Hopefulness, anticipation and confidence about the future or the successful outcome of something. A doctrine that this world is the best possible world."; } }
    public List<string> Synonyms { get { return new List<string> { "hope", "confidence", "buoyancy", "sanguine", "bullishness" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return -.66; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .66 ; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.7; } }
    public double ArousalToNonarousal { get { return -.09; } }
    public double DominanceToSubmissiveness { get { return -.5; } }
	
	public double InnerFocusToOutwardTarget { get { return .5; } }
}