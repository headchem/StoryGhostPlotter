using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Astonishment : IEmotion
{
    public string Id { get { return "astonishment"; } }
    public string Name { get { return "Astonishment"; } }
    public string Description { get { return "A feeling of great surprise and wonder"; } }
    public List<string> Synonyms { get { return new List<string> { "amazement", "bafflement", "bewilderment", "surprise" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .2; } }
    public double FearToAnger { get { return -.2; } }
    public double SurpriseToAnticipation { get { return -1.0; } }

    public double AnxietyToConfidence { get { return -.3; } }
    public double BoredomToFascination { get { return .6; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return -.2; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return -.46; } }
    public double ArousalToNonarousal { get { return -.62; } }
    public double DominanceToSubmissiveness { get { return -.34; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}