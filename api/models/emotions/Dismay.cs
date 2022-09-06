using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Dismay : IEmotion
{
    public string Id { get { return "dismay"; } }
    public string Name { get { return "Dismay"; } }
    public string Description { get { return "The emotion felt when one's expectations are not met."; } }
    public List<string> Synonyms { get { return new List<string> { "letdown", "crestfallen" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 1.0; } }
    public double TrustToDisgust { get { return 0.5; } }
    public double FearToAnger { get { return -.3; } }
    public double SurpriseToAnticipation { get { return -.7; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return -.1; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return 0.52; } }
    public double ArousalToNonarousal { get { return -.42; } }
    public double DominanceToSubmissiveness { get { return .15; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}