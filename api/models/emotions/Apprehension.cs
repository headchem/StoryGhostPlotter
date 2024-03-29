using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Apprehension : IEmotion
{
    public string Id { get { return "apprehension"; } }
    public string Name { get { return "Apprehension"; } }
    public string Description { get { return "Anxiety or fear that something bad or unpleasant will happen"; } }
    public List<string> Synonyms { get { return new List<string> { "anxiety", "angst", "uneasiness", "nervousness", "reluctance" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return -.33; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return -.4; } }
    public double BoredomToFascination { get { return .2; } }
    public double FrustrationToEuphoria { get { return -.2; } }
    public double DispiritedToEncouraged { get { return -.2; } }
    public double TerrorToEnchantment { get { return -.4; } }
    public double HumiliationToPride { get { return -.1; } }

    public double PleasureToDispleasure { get { return .21; } }
    public double ArousalToNonarousal { get { return -.31; } }
    public double DominanceToSubmissiveness { get { return 0.11; } }
	
	public double InnerFocusToOutwardTarget { get { return .3; } }
}