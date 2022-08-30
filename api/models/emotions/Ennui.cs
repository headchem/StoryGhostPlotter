using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Ennui : IEmotion
{
    public string Id { get { return "ennui"; } }
    public string Name { get { return "Ennui"; } }
    public string Description { get { return "A feeling of listlessness and dissatisfaction arising from a lack of occupation or excitement."; } }
    public List<string> Synonyms { get { return new List<string> { "doredom", "listlessness", "weariness" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return .7; } }
    public double TrustToDisgust { get { return .7; } }
    public double FearToAnger { get { return .1; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return 0; } }
    public double BoredomToFascination { get { return -1.0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -.3; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .19; } }
    public double ArousalToNonarousal { get { return 0.08; } }
    public double DominanceToSubmissiveness { get { return .37; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}