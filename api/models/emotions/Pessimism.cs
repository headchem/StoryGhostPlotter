using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Pessimism : IEmotion
{
    public string Id { get { return "pessimism"; } }
    public string Name { get { return "Pessimism"; } }
    public string Description { get { return "An inclination to emphasize adverse aspects, conditions, and possibilities or to expect the worst possible outcome. A lack of hope or confidence in the future."; } }
    public List<string> Synonyms { get { return new List<string> { "defeatism", "negativity" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return 0.3; } }
    public double TrustToDisgust { get { return 0.1; } }
    public double FearToAnger { get { return -.1; } }
    public double SurpriseToAnticipation { get { return 0.3; } }

    public double AnxietyToConfidence { get { return .7; } }
    public double BoredomToFascination { get { return -.5; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return -.7; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return 0.8; } }
    public double ArousalToNonarousal { get { return .1; } }
    public double DominanceToSubmissiveness { get { return .52; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}