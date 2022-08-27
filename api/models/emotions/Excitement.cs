using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Excitement : IEmotion
{
    public string Id { get { return "excitement"; } }
    public string Name { get { return "Excitement"; } }
    public string Description { get { return "A feeling of great enthusiasm and eagerness."; } }
    public List<string> Synonyms { get { return new List<string> { "exhilaration", "animation", "stimulation", "titillation" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.5; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.5; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.74; } }
    public double ArousalToNonarousal { get { return -.76; } }
    public double DominanceToSubmissiveness { get { return -.43; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}