using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Ecstasy : IEmotion
{
    public string Id { get { return "ecstasy"; } }
    public string Name { get { return "Ecstasy"; } }
    public string Description { get { return "A state of overwhelmingly pleasurable emotion."; } }
    public List<string> Synonyms { get { return new List<string> { "cloud nine", "euphoria", "elation", "rhapsody", "rapture" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -1.0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .5; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return 1.0; } }
    public double TerrorToEnchantment { get { return 1.0; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return -0.67; } }
    public double ArousalToNonarousal { get { return -0.75; } }
    public double DominanceToSubmissiveness { get { return -0.4; } }
	
	public double InnerFocusToOutwardTarget { get { return -.2; } }
}