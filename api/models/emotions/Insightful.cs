using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Insightful : IEmotion
{
    public string Id { get { return "insightful"; } }
    public string Name { get { return "Insightful"; } }
    public string Description { get { return ""; } }
    public List<string> Synonyms { get { return new List<string> { }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.2; } }
    public double TrustToDisgust { get { return -.6; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .4; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.28; } }
    public double ArousalToNonarousal { get { return -.05; } }
    public double DominanceToSubmissiveness { get { return -.36; } }

    public double InnerFocusToOutwardTarget { get { return -.2; } }
}