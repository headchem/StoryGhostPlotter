using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Urgency : IEmotion
{
    public string Id { get { return "urgency"; } }
    public string Name { get { return "Urgency"; } }
    public string Description { get { return "Importance requiring swift action. An earnest and persistent quality; insistence."; } }
    public List<string> Synonyms { get { return new List<string> { "insistence", "panic", "pushy", "determination", "tenacity", "pleading" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated, EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .3; } }
    public double FearToAnger { get { return -1.0; } }
    public double SurpriseToAnticipation { get { return 1.0; } }

    public double AnxietyToConfidence { get { return -1.0; } }
    public double BoredomToFascination { get { return .8; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return -.7; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .24; } }
    public double ArousalToNonarousal { get { return -.83; } }
    public double DominanceToSubmissiveness { get { return -.17; } }

    public double InnerFocusToOutwardTarget { get { return 0.7; } }
}