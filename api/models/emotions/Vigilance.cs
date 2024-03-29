using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Vigilance : IEmotion
{
    public string Id { get { return "vigilance"; } }
    public string Name { get { return "Vigilance"; } }
    public string Description { get { return "Alertly watchful especially to avoid danger. The action or state of keeping careful watch for possible danger or difficulties."; } }
    public List<string> Synonyms { get { return new List<string> { "watchfulness", "surveillance", "attentiveness", "attention", "observant" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal, EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 1.0; } }

    public double AnxietyToConfidence { get { return -.3; } }
    public double BoredomToFascination { get { return 1.0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -.1; } }
    public double TerrorToEnchantment { get { return .5; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .04; } }
    public double ArousalToNonarousal { get { return -.26; } }
    public double DominanceToSubmissiveness { get { return -.52; } }
	
	public double InnerFocusToOutwardTarget { get { return 1.0; } }
}