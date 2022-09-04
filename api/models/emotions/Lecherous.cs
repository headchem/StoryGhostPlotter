using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Lecherous : IEmotion
{
    public string Id { get { return "lecherous"; } }
    public string Name { get { return "Lecherous"; } }
    public string Description { get { return "Having or showing excessive or offensive sexual desire."; } }
    public List<string> Synonyms { get { return new List<string> { "lustful", "salacious", "lewd", "sexual" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated, EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.7; } }
    public double TrustToDisgust { get { return 0.4; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.7; } }

    public double AnxietyToConfidence { get { return .6; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .8; } }
    public double HumiliationToPride { get { return .4; } }

    public double PleasureToDispleasure { get { return -.7; } }
    public double ArousalToNonarousal { get { return -.9; } }
    public double DominanceToSubmissiveness { get { return -.9; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}