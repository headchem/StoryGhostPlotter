using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Gratitude : IEmotion
{
    public string Id { get { return "gratitude"; } }
    public string Name { get { return "Gratitude"; } }
    public string Description { get { return "Acknowledgment of having received something good from another"; } }
    public List<string> Synonyms { get { return new List<string> { "appreciation", "grateful", "thankful" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.5; } }
    public double TrustToDisgust { get { return -.7; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.3; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.84; } }
    public double ArousalToNonarousal { get { return .21; } }
    public double DominanceToSubmissiveness { get { return -.17; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}