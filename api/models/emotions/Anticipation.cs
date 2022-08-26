using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Anticipation : IEmotion
{
    public string Id { get { return "anticipation"; } }
    public string Name { get { return "Anticipation"; } }
    public string Description { get { return "The action of anticipating something; expectation or prediction."; } }
    public List<string> Synonyms { get { return new List<string> { "expectation", "prediction", "expectancy" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal, EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .66; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.32; } }
    public double ArousalToNonarousal { get { return -.04; } }
    public double DominanceToSubmissiveness { get { return -.37; } }
	
	public double InnerFocusToOutwardTarget { get { return 1.0; } }
}