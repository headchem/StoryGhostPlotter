using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Entrancement : IEmotion
{
    public string Id { get { return "entrancement"; } }
    public string Name { get { return "Entrancement"; } }
    public string Description { get { return "To fill with overwhelming emotion (as wonder or delight)"; } }
    public List<string> Synonyms { get { return new List<string> { "enrapture", "enthrall" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return -.5; } }
    public double TrustToDisgust { get { return -.5; } }
    public double FearToAnger { get { return -.2; } }
    public double SurpriseToAnticipation { get { return -.3; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.4; } }
    public double ArousalToNonarousal { get { return .21; } }
    public double DominanceToSubmissiveness { get { return -.05; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}