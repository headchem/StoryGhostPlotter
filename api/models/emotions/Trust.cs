using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Trust : IEmotion
{
    public string Id { get { return "trust"; } }
    public string Name { get { return "Trust"; } }
    public string Description { get { return "Believe in the reliability, truth, ability, or strength of. Assured reliance on the character, ability, strength, or truth of someone or something"; } }
    public List<string> Synonyms { get { return new List<string> { "confidence", "faith" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return -.66; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return 1.0; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return -.81; } }
    public double ArousalToNonarousal { get { return .09; } }
    public double DominanceToSubmissiveness { get { return -.54; } }
	
	public double InnerFocusToOutwardTarget { get { return .5; } }
}