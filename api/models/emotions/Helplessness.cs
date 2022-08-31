using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Helplessness : IEmotion
{
    public string Id { get { return "helplessness"; } }
    public string Name { get { return "Helplessness"; } }
    public string Description { get { return "The lack of sufficient ability, power, or means"; } }
    public List<string> Synonyms { get { return new List<string> { "powerless", "impotence", "inadequacy", "incapacity" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return .5; } }
    public double TrustToDisgust { get { return .2; } }
    public double FearToAnger { get { return -.7; } }
    public double SurpriseToAnticipation { get { return -.5; } }

    public double AnxietyToConfidence { get { return -1.0; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return -.3; } }
    public double DispiritedToEncouraged { get { return -.7; } }
    public double TerrorToEnchantment { get { return -.8; } }
    public double HumiliationToPride { get { return -.5; } }

    public double PleasureToDispleasure { get { return .81; } }
    public double ArousalToNonarousal { get { return .1; } }
    public double DominanceToSubmissiveness { get { return .54; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}