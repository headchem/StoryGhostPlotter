using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Nostalgia : IEmotion
{
    public string Id { get { return "nostalgia"; } }
    public string Name { get { return "Nostalgia"; } }
    public string Description { get { return "A sentimental longing or wistful affection for return to or of some past irrecoverable condition, typically for a period or place with happy personal associations."; } }
    public List<string> Synonyms { get { return new List<string> { "wistful", "reminiscence", "rememberance" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return .3; } }
    public double TrustToDisgust { get { return -.2; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .12; } }
    public double ArousalToNonarousal { get { return .31; } }
    public double DominanceToSubmissiveness { get { return .48; } }

    public double InnerFocusToOutwardTarget { get { return -.8; } }
}