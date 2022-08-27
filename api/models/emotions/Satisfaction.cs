using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Satisfaction : IEmotion
{
    public string Id { get { return "satisfaction"; } }
    public string Name { get { return "Satisfaction"; } }
    public string Description { get { return "Fulfillment of one's wishes, expectations, or needs, or the pleasure derived from this."; } }
    public List<string> Synonyms { get { return new List<string> { "contentment", "fulfillment", "gratification", "pleasure" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.SelfAppraisal }; } }

    public double JoyToSadness { get { return -.7; } }
    public double TrustToDisgust { get { return -.7; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .3; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.78; } }
    public double ArousalToNonarousal { get { return -.18; } }
    public double DominanceToSubmissiveness { get { return -.45; } }

    public double InnerFocusToOutwardTarget { get { return -.7; } }
}