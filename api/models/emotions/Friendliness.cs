using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Friendliness : IEmotion
{
    public string Id { get { return "friendliness"; } }
    public string Name { get { return "Friendliness"; } }
    public string Description { get { return "Having or showing kindly feeling and sincere interest."; } }
    public List<string> Synonyms { get { return new List<string> { "amicable", "collegial", "genial", "warmhearted" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.2; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .2; } }

    public double AnxietyToConfidence { get { return .6; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return .4; } }
    public double TerrorToEnchantment { get { return .4; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return -.9; } }
    public double ArousalToNonarousal { get { return .33; } }
    public double DominanceToSubmissiveness { get { return -.27; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}