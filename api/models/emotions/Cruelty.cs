using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Cruelty : IEmotion
{
    public string Id { get { return "cruelty"; } }
    public string Name { get { return "Cruelty"; } }
    public string Description { get { return "Callous indifference to or pleasure in causing pain and suffering."; } }
    public List<string> Synonyms { get { return new List<string> { "brutality", "savagery", "inhumanity" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.7; } }
    public double TrustToDisgust { get { return .7; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .7; } }

    public double AnxietyToConfidence { get { return .7; } }
    public double BoredomToFascination { get { return -.7; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .76; } }
    public double ArousalToNonarousal { get { return -.66; } }
    public double DominanceToSubmissiveness { get { return -.3; } }

    public double InnerFocusToOutwardTarget { get { return .8; } }
}