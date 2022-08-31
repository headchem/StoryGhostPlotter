using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Prudishness : IEmotion
{
    public string Id { get { return "prudishness"; } }
    public string Name { get { return "Prudishness"; } }
    public string Description { get { return "A person who is excessively or priggishly attentive to propriety or decorum. Easily shocked by matters relating to sex or nudity."; } }
    public List<string> Synonyms { get { return new List<string> { "puritanical", "killjoy" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0.5; } }
    public double FearToAnger { get { return -.5; } }
    public double SurpriseToAnticipation { get { return .3; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .7; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return .5; } }
    public double HumiliationToPride { get { return -.5; } }

    public double PleasureToDispleasure { get { return .35; } }
    public double ArousalToNonarousal { get { return .18; } }
    public double DominanceToSubmissiveness { get { return .33; } }

    public double InnerFocusToOutwardTarget { get { return .2; } }
}