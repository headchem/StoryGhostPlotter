using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Fear : IEmotion
{
    public string Id { get { return "fear"; } }
    public string Name { get { return "Fear"; } }
    public string Description { get { return "An unpleasant emotion caused by the belief that someone or something is dangerous, likely to cause pain, or a threat."; } }
    public List<string> Synonyms { get { return new List<string> { "fright", "terror", "panic", "horror" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return -.66; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return -1.0; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return -.3; } }
    public double TerrorToEnchantment { get { return -1.0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .82; } }
    public double ArousalToNonarousal { get { return -0.31; } }
    public double DominanceToSubmissiveness { get { return .44; } }
	
	public double InnerFocusToOutwardTarget { get { return .7; } }
}