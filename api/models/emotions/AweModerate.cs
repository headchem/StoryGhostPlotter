using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class AweModerate : IEmotion
{
    public string Id { get { return "awe-moderate"; } }
    public string Name { get { return "Moderate Awe"; } }
    public string Description { get { return "A feeling of reverential respect mixed with fear or wonder."; } }
    public List<string> Synonyms { get { return new List<string> { "wonder", "astonishment", "amazed" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties, EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return -.66; } }
    public double SurpriseToAnticipation { get { return -.66; } }

    public double AnxietyToConfidence { get { return -.2; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .7; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return -0.24; } }
    public double ArousalToNonarousal { get { return -0.38; } }
    public double DominanceToSubmissiveness { get { return -0.18; } }
	
	public double InnerFocusToOutwardTarget { get { return 0.7; } }
}