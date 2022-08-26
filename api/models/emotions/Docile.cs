using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Docile : IEmotion
{
    public string Id { get { return "docile"; } }
    public string Name { get { return "Docile"; } }
    public string Description { get { return "Ready to accept control or instruction; submissive."; } }
    public List<string> Synonyms { get { return new List<string> { "compliant", "obedient", "dutiful", "submissive" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return -.1; } }
    public double TrustToDisgust { get { return -.4; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.21; } }
    public double ArousalToNonarousal { get { return 0.48; } }
    public double DominanceToSubmissiveness { get { return 0.47; } }

    public double InnerFocusToOutwardTarget { get { return -.5; } }
}