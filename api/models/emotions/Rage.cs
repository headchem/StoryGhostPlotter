using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Rage : IEmotion
{
    public string Id { get { return "rage"; } }
    public string Name { get { return "Rage"; } }
    public string Description { get { return "Violent and uncontrolled anger."; } }
    public List<string> Synonyms { get { return new List<string> { "temper", "tumult", "anger", "frenzy", "fury", "uproar", "rampage", "enraged" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 1.0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return -.3; } }
    public double BoredomToFascination { get { return 0.5; } }
    public double FrustrationToEuphoria { get { return -.2; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return 1.0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .84; } }
    public double ArousalToNonarousal { get { return -.78; } }
    public double DominanceToSubmissiveness { get { return -.32; } }
	
	public double InnerFocusToOutwardTarget { get { return 1.0; } }
}