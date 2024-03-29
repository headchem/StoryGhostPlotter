using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Impressed : IEmotion
{
    public string Id { get { return "impressed"; } }
    public string Name { get { return "Impressed"; } }
    public string Description { get { return "To affect especially forcibly or deeply; gain the admiration or interest of."; } }
    public List<string> Synonyms { get { return new List<string> { "influenced", "moved", "struck", "swayed", "touched", "affected", "impacted" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return -.3; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.5; } }

    public double AnxietyToConfidence { get { return 1.0; } }
    public double BoredomToFascination { get { return 1.0; } }
    public double FrustrationToEuphoria { get { return 1.0; } }
    public double DispiritedToEncouraged { get { return .5; } }
    public double TerrorToEnchantment { get { return .5; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return -.6; } }
    public double ArousalToNonarousal { get { return -.56; } }
    public double DominanceToSubmissiveness { get { return -.46; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}