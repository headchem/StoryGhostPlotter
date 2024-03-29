using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Deference : IEmotion
{
    public string Id { get { return "deference"; } }
    public string Name { get { return "Deference"; } }
    public string Description { get { return "Humble submission and respect."; } }
    public List<string> Synonyms { get { return new List<string> { "yielding", "capitulation", "respect", "regard", "esteem", "consideration", "reverence", "acquiescense" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return -.5; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.3; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return -.3; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return -.3; } }

    public double PleasureToDispleasure { get { return -.02; } }
    public double ArousalToNonarousal { get { return 0.21; } }
    public double DominanceToSubmissiveness { get { return 0.11; } }

    public double InnerFocusToOutwardTarget { get { return 0.5; } }
}