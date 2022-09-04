using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Smug : IEmotion
{
    public string Id { get { return "smug"; } }
    public string Name { get { return "Smug"; } }
    public string Description { get { return "The experience of pleasure, joy, or self-satisfaction that comes from learning of or witnessing the troubles, failures, or humiliation of another."; } }
    public List<string> Synonyms { get { return new List<string> { "schadenfreude", "gloat" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return -.5; } }
    public double TrustToDisgust { get { return .5; } }
    public double FearToAnger { get { return 0.5; } }
    public double SurpriseToAnticipation { get { return -.5; } }

    public double AnxietyToConfidence { get { return .5; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return .7; } }
    public double DispiritedToEncouraged { get { return .9; } }
    public double TerrorToEnchantment { get { return .5; } }
    public double HumiliationToPride { get { return .8; } }

    public double PleasureToDispleasure { get { return -.7; } }
    public double ArousalToNonarousal { get { return -.4; } }
    public double DominanceToSubmissiveness { get { return -.5; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}