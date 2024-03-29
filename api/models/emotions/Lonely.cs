using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Lonely : IEmotion
{
    public string Id { get { return "lonely"; } }
    public string Name { get { return "Lonely"; } }
    public string Description { get { return "Not being in the company of others. Sad because one has no friends or company. Without companions; solitary."; } }
    public List<string> Synonyms { get { return new List<string> { "isolated", "solitary", "alone", "unaccompanied" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return 0.4; } }
    public double TrustToDisgust { get { return -.1; } }
    public double FearToAnger { get { return -.2; } }
    public double SurpriseToAnticipation { get { return .1; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return -.5; } }
    public double FrustrationToEuphoria { get { return -.1; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return -.5; } }

    public double PleasureToDispleasure { get { return 0.6; } }
    public double ArousalToNonarousal { get { return 0.59; } }
    public double DominanceToSubmissiveness { get { return 0.54; } }

    public double InnerFocusToOutwardTarget { get { return -.8; } }
}