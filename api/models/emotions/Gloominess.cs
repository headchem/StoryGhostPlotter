using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Gloominess : IEmotion
{
    public string Id { get { return "gloominess"; } }
    public string Name { get { return "Gloominess"; } }
    public string Description { get { return "The state of being unhappy or without hope; a spell of low spirits."; } }
    public List<string> Synonyms { get { return new List<string> { "blues", "despondent", "doleful", "forlorn", "mopey" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return .7; } }
    public double TrustToDisgust { get { return .3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 1.0; } }

    public double AnxietyToConfidence { get { return -.3; } }
    public double BoredomToFascination { get { return -.5; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return -.1; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .76; } }
    public double ArousalToNonarousal { get { return .19; } }
    public double DominanceToSubmissiveness { get { return .52; } }

    public double InnerFocusToOutwardTarget { get { return -.1; } }
}