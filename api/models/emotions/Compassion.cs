using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Compassion : IEmotion
{
    public string Id { get { return "compassion"; } }
    public string Name { get { return "Compassion"; } }
    public string Description { get { return "Sorrow or the capacity to feel sorrow for another's unhappiness, suffering or misfortune."; } }
    public List<string> Synonyms { get { return new List<string> { "bigheartedness", "commiseration", "sympathy" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.2; } }
    public double TrustToDisgust { get { return -.5; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .2; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.59; } }
    public double ArousalToNonarousal { get { return .34; } }
    public double DominanceToSubmissiveness { get { return .08; } }

    public double InnerFocusToOutwardTarget { get { return .3; } }
}