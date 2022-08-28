using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Disgust : IEmotion
{
    public string Id { get { return "disgust"; } }
    public string Name { get { return "Disgust"; } }
    public string Description { get { return "A dislike so strong as to cause stomach upset or queasiness."; } }
    public List<string> Synonyms { get { return new List<string> { "nausea", "repugnance", "abhorrence", "revolted" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .66; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .91; } }
    public double ArousalToNonarousal { get { return -.56; } }
    public double DominanceToSubmissiveness { get { return .44; } }
	
	public double InnerFocusToOutwardTarget { get { return 1.0; } }
}