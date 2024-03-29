using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Surprise : IEmotion
{
    public string Id { get { return "surprise"; } }
    public string Name { get { return "Surprise"; } }
    public string Description { get { return "The feeling caused by something unexpected or unusual. To cause astonishment."; } }
    public List<string> Synonyms { get { return new List<string> { "astonishment", "shock", "bombshell", "revelation", "amaze", "startle", "stun", "flabbergast" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.66; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return 1.0; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return -.5; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return -0.71; } }
    public double ArousalToNonarousal { get { return -.66; } }
    public double DominanceToSubmissiveness { get { return -.31; } }
	
	public double InnerFocusToOutwardTarget { get { return .8; } }
}