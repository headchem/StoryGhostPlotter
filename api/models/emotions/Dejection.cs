using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Dejection : IEmotion
{
    public string Id { get { return "dejection"; } }
    public string Name { get { return "Dejection"; } }
    public string Description { get { return "A sad and depressed state; low spirits."; } }
    public List<string> Synonyms { get { return new List<string> { "despondency", "downheartedness", "discouragement", "forlornness" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0.7; } }
    public double TrustToDisgust { get { return 0.5; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.3; } }

    public double AnxietyToConfidence { get { return -.3; } }
    public double BoredomToFascination { get { return -.3; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return .2; } }
    public double HumiliationToPride { get { return -.3; } }

    public double PleasureToDispleasure { get { return .79; } }
    public double ArousalToNonarousal { get { return -.31; } }
    public double DominanceToSubmissiveness { get { return .31; } }

    public double InnerFocusToOutwardTarget { get { return -.5; } }
}