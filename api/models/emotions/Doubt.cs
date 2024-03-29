using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Doubt : IEmotion
{
    public string Id { get { return "doubt"; } }
    public string Name { get { return "Doubt"; } }
    public string Description { get { return "A feeling of uncertainty or lack of conviction."; } }
    public List<string> Synonyms { get { return new List<string> { "uncertainty", "indecision", "hesitation" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return 0.1; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return -.3; } }
    public double SurpriseToAnticipation { get { return .2; } }

    public double AnxietyToConfidence { get { return -.7; } }
    public double BoredomToFascination { get { return .7; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return -.4; } }
    public double TerrorToEnchantment { get { return -.4; } }
    public double HumiliationToPride { get { return -.3; } }

    public double PleasureToDispleasure { get { return .41; } }
    public double ArousalToNonarousal { get { return 0.09; } }
    public double DominanceToSubmissiveness { get { return .52; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}