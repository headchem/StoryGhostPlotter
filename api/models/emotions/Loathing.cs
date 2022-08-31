using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Loathing : IEmotion
{
    public string Id { get { return "loathing"; } }
    public string Name { get { return "Loathing"; } }
    public string Description { get { return "A feeling of intense dislike or disgust; hatred. A dislike so strong as to cause stomach upset or queasiness"; } }
    public List<string> Synonyms { get { return new List<string> { "repulsion", "abhorrence", "hatred" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 1.0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return -.3; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return 1.0; } }

    public double PleasureToDispleasure { get { return .81; } }
    public double ArousalToNonarousal { get { return -.49; } }
    public double DominanceToSubmissiveness { get { return .2; } }
	
	public double InnerFocusToOutwardTarget { get { return .6; } }
}