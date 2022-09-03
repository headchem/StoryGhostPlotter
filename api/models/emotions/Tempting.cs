using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Tempting : IEmotion
{
    public string Id { get { return "tempting"; } }
    public string Name { get { return "Tempting"; } }
    public string Description { get { return "Appealing to or attracting someone, even if wrong or inadvisable."; } }
    public List<string> Synonyms { get { return new List<string> { "enticing", "alluring", "appealing", "inviting", "captivating" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.2; } }
    public double TrustToDisgust { get { return -.5; } }
    public double FearToAnger { get { return -.3; } }
    public double SurpriseToAnticipation { get { return .7; } }

    public double AnxietyToConfidence { get { return .7; } }
    public double BoredomToFascination { get { return .1; } }
    public double FrustrationToEuphoria { get { return .6; } }
    public double DispiritedToEncouraged { get { return .5; } }
    public double TerrorToEnchantment { get { return .8; } }
    public double HumiliationToPride { get { return .5; } }

    public double PleasureToDispleasure { get { return 0.14; } }
    public double ArousalToNonarousal { get { return -.56; } }
    public double DominanceToSubmissiveness { get { return -.11; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}