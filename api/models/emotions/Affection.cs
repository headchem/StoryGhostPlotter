using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Affection : IEmotion
{
    public string Id { get { return "affection"; } }
    public string Name { get { return "Affection"; } }
    public string Description { get { return "A gentle feeling of fondness or liking."; } }
    public List<string> Synonyms { get { return new List<string> { "fondness", "liking", "endearment" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.4; } }
    public double TrustToDisgust { get { return -.5; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.3; } }

    public double AnxietyToConfidence { get { return .2; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return .7; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .8; } }
    public double HumiliationToPride { get { return .1; } }

    public double PleasureToDispleasure { get { return -.74; } }
    public double ArousalToNonarousal { get { return -.02; } }
    public double DominanceToSubmissiveness { get { return -.27; } }

    public double InnerFocusToOutwardTarget { get { return .8; } }
}