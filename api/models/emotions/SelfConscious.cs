using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class SelfConscious : IEmotion
{
    public string Id { get { return "self-conscious"; } }
    public string Name { get { return "Self-Conscious"; } }
    public string Description { get { return "Uncomfortably conscious of oneself as an object of the observation of others. Feeling undue awareness of oneself, one's appearance, or one's actions."; } }
    public List<string> Synonyms { get { return new List<string> { "embarrassed", "uncomfortable", "tense" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.SelfAppraisal }; } }

    public double JoyToSadness { get { return 0.1; } }
    public double TrustToDisgust { get { return 0.3; } }
    public double FearToAnger { get { return -.3; } }
    public double SurpriseToAnticipation { get { return 0.3; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return .5; } }
    public double DispiritedToEncouraged { get { return -.7; } }
    public double TerrorToEnchantment { get { return -.5; } }
    public double HumiliationToPride { get { return -.6; } }

    public double PleasureToDispleasure { get { return -.3; } }
    public double ArousalToNonarousal { get { return .3; } }
    public double DominanceToSubmissiveness { get { return .5; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}