using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Annoyance : IEmotion
{
    public string Id { get { return "annoyance"; } }
    public string Name { get { return "Annoyance"; } }
    public string Description { get { return "An unpleasant mental state that is characterized by irritation and distraction from one's conscious thinking. It can lead to emotions such as frustration and anger. The property of being easily annoyed is called irritability."; } }
    public List<string> Synonyms { get { return new List<string> { "irritation", "exasperation", "indignation" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return .33; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return 0.72; } }
    public double ArousalToNonarousal { get { return -0.49; } }
    public double DominanceToSubmissiveness { get { return .3; } }
	
	public double InnerFocusToOutwardTarget { get { return .7; } }
}