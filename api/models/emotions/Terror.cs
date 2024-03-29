using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Terror : IEmotion
{
    public string Id { get { return "terror"; } }
    public string Name { get { return "Terror"; } }
    public string Description { get { return "A state of intense or overwhelming fear."; } }
    public List<string> Synonyms { get { return new List<string> { "dread", "horror", "fright", "trepidation" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return -1.0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return -1.0; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return -1.0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .89; } }
    public double ArousalToNonarousal { get { return -.81; } }
    public double DominanceToSubmissiveness { get { return .01; } }
	
	public double InnerFocusToOutwardTarget { get { return 1.0; } }
}