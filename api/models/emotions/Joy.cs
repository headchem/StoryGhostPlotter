using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Joy : IEmotion
{
    public string Id { get { return "joy"; } }
    public string Name { get { return "Joy"; } }
    public string Description { get { return "A feeling of great pleasure and happiness."; } }
    public List<string> Synonyms { get { return new List<string> { "happiness", "delight", "jubilation", "exultation" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.66; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.95; } }
    public double ArousalToNonarousal { get { return -.39; } }
    public double DominanceToSubmissiveness { get { return -.42; } }
	
	public double InnerFocusToOutwardTarget { get { return .3; } }
}