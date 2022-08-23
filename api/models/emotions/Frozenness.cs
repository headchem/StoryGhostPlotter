using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Frozenness : IEmotion
{
    public string Id { get { return "frozenness"; } }
    public string Name { get { return "Frozenness"; } }
    public string Description { get { return "paralysis"; } }
    public List<string> Synonyms { get { return new List<string> { }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return .7; } }
    public double TrustToDisgust { get { return .5; } }
    public double FearToAnger { get { return 0; } } // frozeness = fear + anger
    public double SurpriseToAnticipation { get { return -.7; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .54; } }
    public double ArousalToNonarousal { get { return .19; } }
    public double DominanceToSubmissiveness { get { return .23; } }

    public double InnerFocusToOutwardTarget { get { return -.4; } }
}