using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Patience : IEmotion
{
    public string Id { get { return "patience"; } }
    public string Name { get { return "Patience"; } }
    public string Description { get { return "The capacity to accept or tolerate delay, trouble, or suffering without getting angry or upset. Not hasty or impetuous."; } }
    public List<string> Synonyms { get { return new List<string> { "stoic", "tolerant", "uncomplaining", "restraint" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.1; } }
    public double TrustToDisgust { get { return -.4; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.4; } }

    public double AnxietyToConfidence { get { return .5; } }
    public double BoredomToFascination { get { return -.3; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return -.54; } }
    public double ArousalToNonarousal { get { return 0.75; } }
    public double DominanceToSubmissiveness { get { return .23; } }

    public double InnerFocusToOutwardTarget { get { return 0.3; } }
}