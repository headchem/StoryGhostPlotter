using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Pensiveness : IEmotion
{
    public string Id { get { return "pensiveness"; } }
    public string Name { get { return "Pensiveness"; } }
    public string Description { get { return "Suggestive of sad thoughtfulness. Engaged in, involving, or reflecting deep or serious thought. Musingly or dreamily thoughtful."; } }
    public List<string> Synonyms { get { return new List<string> { }; } }
	
    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return .33; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -0.08; } }
    public double ArousalToNonarousal { get { return .56; } }
    public double DominanceToSubmissiveness { get { return -0.6; } }
	
	public double InnerFocusToOutwardTarget { get { return -.5; } }
}