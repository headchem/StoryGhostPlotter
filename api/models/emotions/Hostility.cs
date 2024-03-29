using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Hostility : IEmotion
{
    public string Id { get { return "hostility"; } }
    public string Name { get { return "Hostility"; } }
    public string Description { get { return "A deep-seated ill will"; } }
    public List<string> Synonyms { get { return new List<string> { "animosity", "antagonism", "bad blood", "enmity", "grudge", "rude" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .6; } }
    public double FearToAnger { get { return .4; } }
    public double SurpriseToAnticipation { get { return 0.1; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return .6; } }
    public double TerrorToEnchantment { get { return -.3; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return 0.61; } }
    public double ArousalToNonarousal { get { return -.64; } }
    public double DominanceToSubmissiveness { get { return 0.08; } }

    public double InnerFocusToOutwardTarget { get { return .8; } }
}