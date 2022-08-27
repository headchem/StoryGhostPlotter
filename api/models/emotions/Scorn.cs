using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Scorn : IEmotion
{
    public string Id { get { return "scorn"; } }
    public string Name { get { return "Scorn"; } }
    public string Description { get { return "Open dislike and disrespect or mockery often mixed with indignation. The feeling or belief that someone or something is worthless or despicable; contempt."; } }
    public List<string> Synonyms { get { return new List<string> { "contempt", "derision", "disdain", "derisiveness" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.3; } }
    public double TrustToDisgust { get { return 0.7; } }
    public double FearToAnger { get { return 0.1; } }
    public double SurpriseToAnticipation { get { return 0.4; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .77; } }
    public double ArousalToNonarousal { get { return -.24; } }
    public double DominanceToSubmissiveness { get { return .37; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}