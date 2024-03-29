using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class SubmissionModerate : IEmotion
{
    public string Id { get { return "submission-moderate"; } }
    public string Name { get { return "Moderate Submission"; } }
    public string Description { get { return "The condition of being submissive, humble, or compliant. The action or fact of accepting or yielding to a superior force or to the will or authority of another person."; } }
    public List<string> Synonyms { get { return new List<string> { "deference", "yielding", "capitulation", "acceptance", "consent", "compliance", "obedience", "subordination", "conformity", "cowed" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .66; } }
    public double FearToAnger { get { return .66; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .5; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return .2; } }
    public double TerrorToEnchantment { get { return .2; } }
    public double HumiliationToPride { get { return -.2; } }

    public double PleasureToDispleasure { get { return -.007; } }
    public double ArousalToNonarousal { get { return .15; } }
    public double DominanceToSubmissiveness { get { return .12; } }
	
	public double InnerFocusToOutwardTarget { get { return .2; } }
}