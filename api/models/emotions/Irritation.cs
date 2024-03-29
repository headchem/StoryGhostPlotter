using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Irritation : IEmotion
{
    public string Id { get { return "irritation"; } }
    public string Name { get { return "Irritation"; } }
    public string Description { get { return "The state of feeling annoyed, impatient, or slightly angry."; } }
    public List<string> Synonyms { get { return new List<string> { "annoyance", "indignation", "exasperation", "aggravated" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .7; } }
    public double FearToAnger { get { return .7; } }
    public double SurpriseToAnticipation { get { return -.5; } }

    public double AnxietyToConfidence { get { return -.3; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return -.3; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .71; } }
    public double ArousalToNonarousal { get { return -.7; } }
    public double DominanceToSubmissiveness { get { return .27; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}