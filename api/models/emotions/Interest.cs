using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Interest : IEmotion
{
    public string Id { get { return "interest"; } }
    public string Name { get { return "Interest"; } }
    public string Description { get { return "The state of wanting to know or learn about something or someone."; } }
    public List<string> Synonyms { get { return new List<string> { "attentiveness", "absorption", "engrossment" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal, EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .33; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -0.64; } }
    public double ArousalToNonarousal { get { return -0.28; } }
    public double DominanceToSubmissiveness { get { return -0.38; } }
	
	public double InnerFocusToOutwardTarget { get { return .8; } }
}