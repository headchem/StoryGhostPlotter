using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Cheerfulness : IEmotion
{
    public string Id { get { return "cheerfulness"; } }
    public string Name { get { return "Cheerfulness"; } }
    public string Description { get { return "A mood characterized by high spirits and amusement and often accompanied by laughter"; } }
    public List<string> Synonyms { get { return new List<string> { "festivity", "gaiety", "joviality", "merriment", "playful" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.5; } }
    public double TrustToDisgust { get { return -.1; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .3; } }

    public double AnxietyToConfidence { get { return .5; } }
    public double BoredomToFascination { get { return .2; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return .5; } }
    public double TerrorToEnchantment { get { return .2; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return -.96; } }
    public double ArousalToNonarousal { get { return -.52; } }
    public double DominanceToSubmissiveness { get { return -.37; } }

    public double InnerFocusToOutwardTarget { get { return -.5; } }
}