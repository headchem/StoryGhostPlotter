using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Despair : IEmotion
{
    public string Id { get { return "despair"; } }
    public string Name { get { return "Despair"; } }
    public string Description { get { return "Utter loss of hope."; } }
    public List<string> Synonyms { get { return new List<string> { "desperation", "hopelessness", "forlornness" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 1.0; } }
    public double TrustToDisgust { get { return .3; } }
    public double FearToAnger { get { return -.3; } }
    public double SurpriseToAnticipation { get { return -.6; } }

    public double AnxietyToConfidence { get { return -1.0; } }
    public double BoredomToFascination { get { return -.3; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return -.5; } }
    public double HumiliationToPride { get { return -.3; } }

    public double PleasureToDispleasure { get { return .81; } }
    public double ArousalToNonarousal { get { return -.53; } }
    public double DominanceToSubmissiveness { get { return .47; } }

    public double InnerFocusToOutwardTarget { get { return 0; } }
}