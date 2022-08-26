using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Dispirited : IEmotion
{
    public string Id { get { return "dispirited"; } }
    public string Name { get { return "Dispirited"; } }
    public string Description { get { return "To lessen the courage or confidence of."; } }
    public List<string> Synonyms { get { return new List<string> { "discouraged", "demoralized", "unnerved" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return .5; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.5; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .59; } }
    public double ArousalToNonarousal { get { return .44; } }
    public double DominanceToSubmissiveness { get { return .72; } }

    public double InnerFocusToOutwardTarget { get { return -.5; } }
}