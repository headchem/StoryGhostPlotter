using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Argumentative : IEmotion
{
    public string Id { get { return "argumentative"; } }
    public string Name { get { return "Argumentative"; } }
    public string Description { get { return "Given to expressing divergent or opposite views."; } }
    public List<string> Synonyms { get { return new List<string> { "quarrelsome", "bickering", "contrary", "sassy" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0.4; } }
    public double FearToAnger { get { return 0.4; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return -.4; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return .2; } }
    public double DispiritedToEncouraged { get { return -.2; } }
    public double TerrorToEnchantment { get { return .6; } }
    public double HumiliationToPride { get { return .5; } }

    public double PleasureToDispleasure { get { return 0.1; } }
    public double ArousalToNonarousal { get { return -.06; } }
    public double DominanceToSubmissiveness { get { return -.36; } }

    public double InnerFocusToOutwardTarget { get { return 0.7; } }
}