using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Epiphany : IEmotion
{
    public string Id { get { return "epiphany"; } }
    public string Name { get { return "Epiphany"; } }
    public string Description { get { return "A sudden manifestation or perception of the essential nature or meaning of something."; } }
    public List<string> Synonyms { get { return new List<string> { "insight", "realization" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.3; } }
    public double TrustToDisgust { get { return -.2; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.5; } }

    public double AnxietyToConfidence { get { return .7; } }
    public double BoredomToFascination { get { return .7; } }
    public double FrustrationToEuphoria { get { return 1.0; } }
    public double DispiritedToEncouraged { get { return 1.0; } }
    public double TerrorToEnchantment { get { return .5; } }
    public double HumiliationToPride { get { return .7; } }

    public double PleasureToDispleasure { get { return -.25; } }
    public double ArousalToNonarousal { get { return -.19; } }
    public double DominanceToSubmissiveness { get { return -.05; } }

    public double InnerFocusToOutwardTarget { get { return -.5; } }
}