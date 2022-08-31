using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class RemorseMild : IEmotion
{
    public string Id { get { return "remorse-mild"; } }
    public string Name { get { return "Mild Remorse"; } }
    public string Description { get { return "A gnawing distress arising from a sense of guilt for past wrongs. Deep regret or guilt for a wrong committed."; } }
    public List<string> Synonyms { get { return new List<string> { "contrition", "repentance", "guilt", "penitence" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return .33; } }
    public double TrustToDisgust { get { return .33; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return -.1; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return -.3; } }
    public double HumiliationToPride { get { return -.5; } }

    public double PleasureToDispleasure { get { return .35; } }
    public double ArousalToNonarousal { get { return -.05; } }
    public double DominanceToSubmissiveness { get { return .2; } }
	
	public double InnerFocusToOutwardTarget { get { return -.35; } }
}