using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class ContemptMild : IEmotion
{
    public string Id { get { return "contempt-mild"; } }
    public string Name { get { return "Mild Contempt"; } }
    public string Description { get { return "Open dislike for someone or something considered unworthy of one's concern or respect"; } }
    public List<string> Synonyms { get { return new List<string> { "despisement", "disdain", "scorn" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties, EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .33; } }
    public double FearToAnger { get { return .33; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return -.3; } }
    public double FrustrationToEuphoria { get { return .1; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return .1; } }

    public double PleasureToDispleasure { get { return .3; } }
    public double ArousalToNonarousal { get { return -.08; } }
    public double DominanceToSubmissiveness { get { return .06; } }
	
	public double InnerFocusToOutwardTarget { get { return 1.0; } }
}