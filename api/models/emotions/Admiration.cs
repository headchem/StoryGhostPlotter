using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Admiration : IEmotion
{
    public string Id { get { return "admiration"; } }
    public string Name { get { return "Admiration"; } }
    public string Description { get { return "Respect and warm approval. Something regarded as impressive or worthy of respect. Pleasurable contemplation."; } }
    public List<string> Synonyms { get { return new List<string> { "commendation", "acclaim", "approval", "appreciation", "delight", "pride and joy" }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return -1.0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.78; } }
    public double ArousalToNonarousal { get { return -.24; } }
    public double DominanceToSubmissiveness { get { return -.46; } }
	
	public double InnerFocusToOutwardTarget { get { return .66; } }
}