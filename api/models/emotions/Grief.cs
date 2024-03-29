using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Grief : IEmotion
{
    public string Id { get { return "grief"; } }
    public string Name { get { return "Grief"; } }
    public string Description { get { return "Deep sadness especially for the loss of someone or something loved."; } }
    public List<string> Synonyms { get { return new List<string> { "affliction", "anguish", "heartache", "woe", "sorrow" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 1.0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0.3; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return -.3; } }
    public double HumiliationToPride { get { return -.3; } }

    public double PleasureToDispleasure { get { return .86; } }
    public double ArousalToNonarousal { get { return -.28; } }
    public double DominanceToSubmissiveness { get { return .05; } }
	
	public double InnerFocusToOutwardTarget { get { return -.7; } }
}