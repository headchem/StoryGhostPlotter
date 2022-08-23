using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Greed : IEmotion
{
    public string Id { get { return "greed"; } }
    public string Name { get { return "Greed"; } }
    public string Description { get { return ""; } }
    public List<string> Synonyms { get { return new List<string> { }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.2; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return -.4; } }
    public double SurpriseToAnticipation { get { return .6; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .7; } }
    public double ArousalToNonarousal { get { return -.44; } }
    public double DominanceToSubmissiveness { get { return -.01; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}