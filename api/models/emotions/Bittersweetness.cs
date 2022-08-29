using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Bittersweetness : IEmotion
{
    public string Id { get { return "bittersweetness"; } }
    public string Name { get { return "Bittersweetness"; } }
    public string Description { get { return "Pleasure accompanied by suffering or regret."; } }
    public List<string> Synonyms { get { return new List<string> { "wistful", "malancholy", "heartwarming", "heartbreaking" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return -.5; } }
    public double FearToAnger { get { return -.2; } }
    public double SurpriseToAnticipation { get { return .7; } }

    public double AnxietyToConfidence { get { return .1; } }
    public double BoredomToFascination { get { return .2; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return .2; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .06; } }
    public double ArousalToNonarousal { get { return -.14; } }
    public double DominanceToSubmissiveness { get { return 0.05; } }

    public double InnerFocusToOutwardTarget { get { return -.7; } }
}