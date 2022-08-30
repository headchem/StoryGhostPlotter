using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Depression : IEmotion
{
    public string Id { get { return "depression"; } }
    public string Name { get { return "Depression"; } }
    public string Description { get { return "A state or spell of low spirits."; } }
    public List<string> Synonyms { get { return new List<string> { "dejection", "despondency", "doldrums", "dreary", "mournfulness" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.SelfAppraisal }; } }

    public double JoyToSadness { get { return 1.0; } }
    public double TrustToDisgust { get { return .5; } }
    public double FearToAnger { get { return -.3; } }
    public double SurpriseToAnticipation { get { return .7; } }

    public double AnxietyToConfidence { get { return -.2; } }
    public double BoredomToFascination { get { return -.7; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return -.2; } }

    public double PleasureToDispleasure { get { return .83; } }
    public double ArousalToNonarousal { get { return .02; } }
    public double DominanceToSubmissiveness { get { return 0.61; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}