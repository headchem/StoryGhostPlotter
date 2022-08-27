using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Empathy : IEmotion
{
    public string Id { get { return "empathy"; } }
    public string Name { get { return "Empathy"; } }
    public string Description { get { return "Having or showing the capacity for sharing the feelings of another."; } }
    public List<string> Synonyms { get { return new List<string> { "commiserating", "sympathizing", "soothing" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return 0.5; } }
    public double TrustToDisgust { get { return -.1; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.2; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.53; } }
    public double ArousalToNonarousal { get { return -0.01; } }
    public double DominanceToSubmissiveness { get { return -.18; } }

    public double InnerFocusToOutwardTarget { get { return .8; } }
}