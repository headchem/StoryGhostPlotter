using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Hurt : IEmotion
{
    public string Id { get { return "hurt"; } }
    public string Name { get { return "Hurt"; } }
    public string Description { get { return "To feel deep sadness or mental pain"; } }
    public List<string> Synonyms { get { return new List<string> { "agonize", "anguish", "grieve", "suffer" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return 0.7; } }
    public double TrustToDisgust { get { return 0.2; } }
    public double FearToAnger { get { return -.1; } }
    public double SurpriseToAnticipation { get { return -.7; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .79; } }
    public double ArousalToNonarousal { get { return -.49; } }
    public double DominanceToSubmissiveness { get { return .35; } }

    public double InnerFocusToOutwardTarget { get { return 0; } }
}