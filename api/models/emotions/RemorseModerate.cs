using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class RemorseModerate : IEmotion
{
    public string Id { get { return "remorse-moderate"; } }
    public string Name { get { return "Moderate Remorse"; } }
    public string Description { get { return "A gnawing distress arising from a sense of guilt for past wrongs. Deep regret or guilt for a wrong committed."; } }
    public List<string> Synonyms { get { return new List<string> { "contrition", "repentance", "guilt", "penitence" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return .66; } }
    public double TrustToDisgust { get { return .66; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .45; } }
    public double ArousalToNonarousal { get { return -.07; } }
    public double DominanceToSubmissiveness { get { return .28; } }
	
	public double InnerFocusToOutwardTarget { get { return -.5; } }
}