using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Adoration : IEmotion
{
    public string Id { get { return "adoration"; } }
    public string Name { get { return "Adoration"; } }
    public string Description { get { return "Deep love and respect. Worship and veneration. Adoration is respect, reverence, strong admiration, or love in a certain person, place, or thing."; } }
    public List<string> Synonyms { get { return new List<string> { "love", "devotion", "fondness", "affection", "praise", "revere", "exalt", "laud" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Cathected }; } }

    public double JoyToSadness { get { return -1.0; } }
    public double TrustToDisgust { get { return -.10; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .5; } }

    public double AnxietyToConfidence { get { return .5; } }
    public double BoredomToFascination { get { return .6; } }
    public double FrustrationToEuphoria { get { return .8; } }
    public double DispiritedToEncouraged { get { return .5; } }
    public double TerrorToEnchantment { get { return .8; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return -.77; } }
    public double ArousalToNonarousal { get { return -.4; } }
    public double DominanceToSubmissiveness { get { return -.42; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}