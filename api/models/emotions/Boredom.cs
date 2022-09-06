using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Boredom : IEmotion
{
    public string Id { get { return "boredom"; } }
    public string Name { get { return "Boredom"; } }
    public string Description { get { return "Feeling unsatisfied by an activity, or uninterested in it,"; } }
    public List<string> Synonyms { get { return new List<string> { "weariness", "lack of enthusiasm", "laziness" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .33; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return 0; } }
    public double BoredomToFascination { get { return -1.0; } }
    public double FrustrationToEuphoria { get { return -.4; } }
    public double DispiritedToEncouraged { get { return -.3; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .68; } }
    public double ArousalToNonarousal { get { return .69; } }
    public double DominanceToSubmissiveness { get { return .55; } }
	
	public double InnerFocusToOutwardTarget { get { return -1.0; } }
}