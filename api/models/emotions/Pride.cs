using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Pride : IEmotion
{
    public string Id { get { return "pride"; } }
    public string Name { get { return "Pride"; } }
    public string Description { get { return ""; } }
    public List<string> Synonyms { get { return new List<string> { }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.SelfAppraisal }; } }

    public double JoyToSadness { get { return -.7; } }
    public double TrustToDisgust { get { return -.4; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .6; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.64; } }
    public double ArousalToNonarousal { get { return -.33; } }
    public double DominanceToSubmissiveness { get { return -.72; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}