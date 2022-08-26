using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Distaste : IEmotion
{
    public string Id { get { return "distaste"; } }
    public string Name { get { return "Distaste"; } }
    public string Description { get { return "Mild dislike or aversion."; } }
    public List<string> Synonyms { get { return new List<string> { "dislike", "aversion", "disdain" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0.1; } }
    public double TrustToDisgust { get { return 0.3; } }
    public double FearToAnger { get { return 0.1; } }
    public double SurpriseToAnticipation { get { return -.2; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .55; } }
    public double ArousalToNonarousal { get { return -.3; } }
    public double DominanceToSubmissiveness { get { return .41; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}