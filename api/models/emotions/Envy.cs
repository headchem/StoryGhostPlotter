using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Envy : IEmotion
{
    public string Id { get { return "envy"; } }
    public string Name { get { return "Envy"; } }
    public string Description { get { return "A painful awareness of another's possessions or advantages and a desire to have them too"; } }
    public List<string> Synonyms { get { return new List<string> { "covetousness", "resentment", "jealousy" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return .2; } }
    public double TrustToDisgust { get { return .3; } }
    public double FearToAnger { get { return .1; } }
    public double SurpriseToAnticipation { get { return .5; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .65; } }
    public double ArousalToNonarousal { get { return -.46; } }
    public double DominanceToSubmissiveness { get { return .23; } }

    public double InnerFocusToOutwardTarget { get { return .8; } }
}