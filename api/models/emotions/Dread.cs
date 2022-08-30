using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Dread : IEmotion
{
    public string Id { get { return "dread"; } }
    public string Name { get { return "Dread"; } }
    public string Description { get { return "Anticipate with great apprehension or fear."; } }
    public List<string> Synonyms { get { return new List<string> { "fear", "anxiety", "terrifying" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return .2; } }
    public double TrustToDisgust { get { return .1; } }
    public double FearToAnger { get { return -1.0; } }
    public double SurpriseToAnticipation { get { return 1.0; } }

    public double AnxietyToConfidence { get { return -1.0; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -.3; } }
    public double TerrorToEnchantment { get { return 1.0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .73; } }
    public double ArousalToNonarousal { get { return -.51; } }
    public double DominanceToSubmissiveness { get { return .2; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}