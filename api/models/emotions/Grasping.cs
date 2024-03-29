using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Grasping : IEmotion
{
    public string Id { get { return "grasping"; } }
    public string Name { get { return "Grasping"; } }
    public string Description { get { return "Having or marked by an eager and often selfish desire especially for material possessions"; } }
    public List<string> Synonyms { get { return new List<string> { "acquisitive", "covetous", "greedy", "moneygrubbing" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0.3; } }
    public double TrustToDisgust { get { return 0.1; } }
    public double FearToAnger { get { return -.7; } }
    public double SurpriseToAnticipation { get { return 0.5; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .9; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return -.3; } }
    public double HumiliationToPride { get { return -.1; } }

    public double PleasureToDispleasure { get { return .35; } }
    public double ArousalToNonarousal { get { return -.12; } }
    public double DominanceToSubmissiveness { get { return -.12; } }

    public double InnerFocusToOutwardTarget { get { return 0.3; } }
}