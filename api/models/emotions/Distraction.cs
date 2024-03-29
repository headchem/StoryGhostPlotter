using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Distraction : IEmotion
{
    public string Id { get { return "distraction"; } }
    public string Name { get { return "Distraction"; } }
    public string Description { get { return "Agitation of the mind or emotions. Not giving full attention to something else."; } }
    public List<string> Synonyms { get { return new List<string> { "diversion", "interrupted" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.33; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -.1; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .36; } }
    public double ArousalToNonarousal { get { return -0.07; } }
    public double DominanceToSubmissiveness { get { return .33; } }
	
	public double InnerFocusToOutwardTarget { get { return .5; } }
}