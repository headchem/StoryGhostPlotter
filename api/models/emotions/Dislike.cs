using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Dislike : IEmotion
{
    public string Id { get { return "dislike"; } }
    public string Name { get { return "Dislike"; } }
    public string Description { get { return "A strong feeling of not liking or approving. Refusal to accept as right or desirable."; } }
    public List<string> Synonyms { get { return new List<string> { "disinclination", "averseness", "disfavor" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return .2; } }
    public double TrustToDisgust { get { return .3; } }
    public double FearToAnger { get { return .1; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return -.3; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return -.1; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .75; } }
    public double ArousalToNonarousal { get { return -.04; } }
    public double DominanceToSubmissiveness { get { return 0.39; } }

    public double InnerFocusToOutwardTarget { get { return .4; } }
}