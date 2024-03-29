using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Expectancy : IEmotion
{
    public string Id { get { return "expectancy"; } }
    public string Name { get { return "Expectancy"; } }
    public string Description { get { return "The state of thinking or hoping that something, especially something pleasant, will happen or be the case."; } }
    public List<string> Synonyms { get { return new List<string> { "anticipation", "hopefulness", "prospect" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return -.2; } }
    public double FearToAnger { get { return -.1; } }
    public double SurpriseToAnticipation { get { return 1.0; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return 1.0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return 1.0; } }
    public double TerrorToEnchantment { get { return 1.0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return -.25; } }
    public double ArousalToNonarousal { get { return -.11; } }
    public double DominanceToSubmissiveness { get { return -.04; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}