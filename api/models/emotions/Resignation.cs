using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Resignation : IEmotion
{
    public string Id { get { return "resignation"; } }
    public string Name { get { return "Resignation"; } }
    public string Description { get { return "The acceptance of something undesirable but inevitable."; } }
    public List<string> Synonyms { get { return new List<string> { "endurance", "fortitude", "tolerance", "forbearance" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return 0.6; } }
    public double TrustToDisgust { get { return 0.3; } }
    public double FearToAnger { get { return 0.4; } }
    public double SurpriseToAnticipation { get { return 0.6; } }

    public double AnxietyToConfidence { get { return .4; } }
    public double BoredomToFascination { get { return -.8; } }
    public double FrustrationToEuphoria { get { return 0.2; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return .2; } }
    public double HumiliationToPride { get { return -.5; } }

    public double PleasureToDispleasure { get { return 0.71; } }
    public double ArousalToNonarousal { get { return 0.22; } }
    public double DominanceToSubmissiveness { get { return 0.38; } }

    public double InnerFocusToOutwardTarget { get { return -.5; } }
}