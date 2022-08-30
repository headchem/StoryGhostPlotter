using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Easiness : IEmotion
{
    public string Id { get { return "easiness"; } }
    public string Name { get { return "Easiness"; } }
    public string Description { get { return "Having a relaxed, casual manner"; } }
    public List<string> Synonyms { get { return new List<string> { "easygoing", "affable", "happy-go-lucky", "mellow", "laid-back" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated, EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return -.3; } }
    public double TrustToDisgust { get { return -.5; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .5; } }
    public double BoredomToFascination { get { return -.1; } }
    public double FrustrationToEuphoria { get { return .1; } }
    public double DispiritedToEncouraged { get { return .2; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return -.72; } }
    public double ArousalToNonarousal { get { return 0.5; } }
    public double DominanceToSubmissiveness { get { return 0.09; } }

    public double InnerFocusToOutwardTarget { get { return -.7; } }
}