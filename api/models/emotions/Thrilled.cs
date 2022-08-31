using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Thrilled : IEmotion
{
    public string Id { get { return "thrilled"; } }
    public string Name { get { return "Thrilled"; } }
    public string Description { get { return "Extremely pleased and excited. Cause (someone) to have a sudden feeling of excitement and pleasure."; } }
    public List<string> Synonyms { get { return new List<string> { "excite", "stimulate", "arouse", "inspire", "delight"}; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -1.0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -1.0; } }

    public double AnxietyToConfidence { get { return 1.0; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return 1.0; } }
    public double DispiritedToEncouraged { get { return 1.0; } }
    public double TerrorToEnchantment { get { return 1.0; } }
    public double HumiliationToPride { get { return .5; } }

    public double PleasureToDispleasure { get { return -.81; } }
    public double ArousalToNonarousal { get { return -.65; } }
    public double DominanceToSubmissiveness { get { return -.53; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}