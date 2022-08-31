using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Miserliness : IEmotion
{
    public string Id { get { return "miserliness"; } }
    public string Name { get { return "Miserliness"; } }
    public string Description { get { return "Excessive desire to save money; extreme meanness. The quality or practice of being overly sparing with money."; } }
    public List<string> Synonyms { get { return new List<string> { "cheapness", "penny-pinching", "stinginess", "economizing", "avarice" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .7; } }
    public double FearToAnger { get { return .3; } }
    public double SurpriseToAnticipation { get { return .5; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return -.2; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return .2; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return .6; } }

    public double PleasureToDispleasure { get { return .64; } }
    public double ArousalToNonarousal { get { return -.11; } }
    public double DominanceToSubmissiveness { get { return .36; } }

    public double InnerFocusToOutwardTarget { get { return .3; } }
}