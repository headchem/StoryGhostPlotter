using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Derisiveness : IEmotion
{
    public string Id { get { return "derisiveness"; } }
    public string Name { get { return "Derisiveness"; } }
    public string Description { get { return "So foolish or pointless as to be worthy of scornful laughter."; } }
    public List<string> Synonyms { get { return new List<string> { "absurd", "farcical", "laughable", "ludicrous", "comical", "preposterous", "risible", "rude" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties, EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.4; } }
    public double TrustToDisgust { get { return .7; } }
    public double FearToAnger { get { return .3; } }
    public double SurpriseToAnticipation { get { return .5; } }

    public double AnxietyToConfidence { get { return 0; } }
    public double BoredomToFascination { get { return -.3; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return .5; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return .5; } }

    public double PleasureToDispleasure { get { return .47; } }
    public double ArousalToNonarousal { get { return -.34; } }
    public double DominanceToSubmissiveness { get { return .42; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}