using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Anger : IEmotion
{
    public string Id { get { return "anger"; } }
    public string Name { get { return "Anger"; } }
    public string Description { get { return "A strong feeling of annoyance, displeasure, or hostility."; } }
    public List<string> Synonyms { get { return new List<string> { "vexation", "crossness", "irk" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return .66; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .2; } }
    public double BoredomToFascination { get { return .4; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return .8; } }
    public double ArousalToNonarousal { get { return -.72; } }
    public double DominanceToSubmissiveness { get { return -.12; } }
	
	public double InnerFocusToOutwardTarget { get { return .4; } }
}