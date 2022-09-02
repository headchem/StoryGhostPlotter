using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Seething : IEmotion
{
    public string Id { get { return "seething"; } }
    public string Name { get { return "Seething"; } }
    public string Description { get { return "Filled with or characterized by intense but unexpressed anger. To be excited or emotionally stirred up with anger."; } }
    public List<string> Synonyms { get { return new List<string> { "fuming", "smoldering", "bristling", "chafing" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .7; } }
    public double FearToAnger { get { return 1.0; } }
    public double SurpriseToAnticipation { get { return -.3; } }

    public double AnxietyToConfidence { get { return -.3; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return -.8; } }
    public double TerrorToEnchantment { get { return -.2; } }
    public double HumiliationToPride { get { return -.3; } }

    public double PleasureToDispleasure { get { return 0.38; } }
    public double ArousalToNonarousal { get { return -.64; } }
    public double DominanceToSubmissiveness { get { return -.28; } }

    public double InnerFocusToOutwardTarget { get { return -.3; } }
}