using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Arrogance : IEmotion
{
    public string Id { get { return "arrogance"; } }
    public string Name { get { return "Arrogance"; } }
    public string Description { get { return "An attitude of superiority manifested in an overbearing manner or in presumptuous claims or assumptions."; } }
    public List<string> Synonyms { get { return new List<string> { "haughtiness", "conceit", "hubris", "self-importance", "egotism" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.3; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .3; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .74; } }
    public double ArousalToNonarousal { get { return -.51; } }
    public double DominanceToSubmissiveness { get { return -.2; } }

    public double InnerFocusToOutwardTarget { get { return -.7; } }
}