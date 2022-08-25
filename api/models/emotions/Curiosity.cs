using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Curiosity : IEmotion
{
    public string Id { get { return "curiosity"; } }
    public string Name { get { return "Curiosity"; } }
    public string Description { get { return ""; } }
    public List<string> Synonyms { get { return new List<string> { }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return -.3; } }
    public double TrustToDisgust { get { return -.4; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.5; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.39; } }
    public double ArousalToNonarousal { get { return -.35; } }
    public double DominanceToSubmissiveness { get { return 0.05; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}