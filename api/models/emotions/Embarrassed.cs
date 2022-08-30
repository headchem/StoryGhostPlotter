using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Embarrassed : IEmotion
{
    public string Id { get { return "embarrassed"; } }
    public string Name { get { return "Embarrassed"; } }
    public string Description { get { return "To throw into a state of self-conscious distress"; } }
    public List<string> Synonyms { get { return new List<string> { "abashed", "self-conscious", "insecure", "uptight" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.SelfAppraisal }; } }

    public double JoyToSadness { get { return .7; } }
    public double TrustToDisgust { get { return .7; } }
    public double FearToAnger { get { return .5; } }
    public double SurpriseToAnticipation { get { return 0.3; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -.7; } }
    public double TerrorToEnchantment { get { return -.3; } }
    public double HumiliationToPride { get { return -1.0; } }

    public double PleasureToDispleasure { get { return .68; } }
    public double ArousalToNonarousal { get { return -.36; } }
    public double DominanceToSubmissiveness { get { return .47; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}