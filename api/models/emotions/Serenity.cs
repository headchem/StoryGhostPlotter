using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Serenity : IEmotion
{
    public string Id { get { return "serenity"; } }
    public string Name { get { return "Serenity"; } }
    public string Description { get { return "The state of being calm, peaceful, and untroubled. Marked by or suggestive of utter calm and unruffled repose or quietude."; } }
    public List<string> Synonyms { get { return new List<string> { "peaceful", "quietude", "calm", "placid", "restful", "tranquil", "composed" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return -.33; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .4; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return .1; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return .1; } }

    public double PleasureToDispleasure { get { return -0.8; } }
    public double ArousalToNonarousal { get { return .76; } }
    public double DominanceToSubmissiveness { get { return -.11; } }
	
	public double InnerFocusToOutwardTarget { get { return -1.0; } }
}