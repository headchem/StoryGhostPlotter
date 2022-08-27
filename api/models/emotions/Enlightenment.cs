using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Enlightenment : IEmotion
{
    public string Id { get { return "enlightenment"; } }
    public string Name { get { return "Enlightenment"; } }
    public string Description { get { return "The process by which one gains a greater understanding of something."; } }
    public List<string> Synonyms { get { return new List<string> { "realization", "awareness", "erudition", "learning" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.7; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.7; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.67; } }
    public double ArousalToNonarousal { get { return -.2; } }
    public double DominanceToSubmissiveness { get { return -.36; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}