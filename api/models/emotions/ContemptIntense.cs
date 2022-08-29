using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class ContemptIntense : IEmotion
{
    public string Id { get { return "contempt-intense"; } }
    public string Name { get { return "Intense Contempt"; } }
    public string Description { get { return "Open dislike for someone or something considered unworthy of one's concern or respect"; } }
    public List<string> Synonyms { get { return new List<string> { "despisement", "disdain", "scorn" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties, EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 1.0; } }
    public double FearToAnger { get { return 1.0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .7; } }
    public double BoredomToFascination { get { return -.7; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return .63; } }
    public double ArousalToNonarousal { get { return -.19; } }
    public double DominanceToSubmissiveness { get { return .17; } }
	
	public double InnerFocusToOutwardTarget { get { return 1.0; } }
}