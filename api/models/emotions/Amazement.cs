using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Amazement : IEmotion
{
    public string Id { get { return "amazement"; } }
    public string Name { get { return "Amazement"; } }
    public string Description { get { return "A feeling of great surprise or wonder."; } }
    public List<string> Synonyms { get { return new List<string> { "astonishment", "bewilderment", "stupefaction", "surprise", "shock" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -1.0; } }

    public double AnxietyToConfidence { get { return -.3; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return .1; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return -0.7; } }
    public double ArousalToNonarousal { get { return -0.63; } }
    public double DominanceToSubmissiveness { get { return -0.41; } }
	
	public double InnerFocusToOutwardTarget { get { return .7; } }
}