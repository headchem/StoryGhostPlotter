using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Sadness : IEmotion
{
    public string Id { get { return "sadness"; } }
    public string Name { get { return "Sadness"; } }
    public string Description { get { return "An emotional state characterized by feelings of unhappiness and low mood. Affected with or expressive of grief or unhappiness."; } }
    public List<string> Synonyms { get { return new List<string> { "blue", "downcast", "depressed", "despondent", "doleful", "glum", "low-spirited", "melancholy", "miserable", "mournful", "woebegone", "wretched" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return .66; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .9; } }
    public double ArousalToNonarousal { get { return .42; } }
    public double DominanceToSubmissiveness { get { return .67; } }
	
	public double InnerFocusToOutwardTarget { get { return -.8; } }
}