using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Hate : IEmotion
{
    public string Id { get { return "hate"; } }
    public string Name { get { return "Hate"; } }
    public string Description { get { return "To dislike strongly"; } }
    public List<string> Synonyms { get { return new List<string> { "abhor", "detest", "despise" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Cathected }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0.7; } }
    public double FearToAnger { get { return 1.0; } }
    public double SurpriseToAnticipation { get { return .5; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .91; } }
    public double ArousalToNonarousal { get { return -.65; } }
    public double DominanceToSubmissiveness { get { return .14; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}