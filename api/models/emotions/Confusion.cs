using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Confusion : IEmotion
{
    public string Id { get { return "confusion"; } }
    public string Name { get { return "Confusion"; } }
    public string Description { get { return "A state of mental uncertainty."; } }
    public List<string> Synonyms { get { return new List<string> { "bafflement", "discombobulation", "perplexity" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return .3; } }
    public double TrustToDisgust { get { return .3; } }
    public double FearToAnger { get { return .3; } }
    public double SurpriseToAnticipation { get { return -.7; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return -.3; } }
    public double TerrorToEnchantment { get { return -.3; } }
    public double HumiliationToPride { get { return -.1; } }

    public double PleasureToDispleasure { get { return .6; } }
    public double ArousalToNonarousal { get { return -.29; } }
    public double DominanceToSubmissiveness { get { return .53; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}