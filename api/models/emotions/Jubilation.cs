using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Jubilation : IEmotion
{
    public string Id { get { return "jubilation"; } }
    public string Name { get { return "Jubilation"; } }
    public string Description { get { return "A feeling of great happiness and triumph."; } }
    public List<string> Synonyms { get { return new List<string> { "triumph", "rejoicing", "euphoria", "elation" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -1.0; } }
    public double TrustToDisgust { get { return -.5; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return 1.0; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return .5; } }
    public double DispiritedToEncouraged { get { return 1.0; } }
    public double TerrorToEnchantment { get { return 1.0; } }
    public double HumiliationToPride { get { return 1.0; } }

    public double PleasureToDispleasure { get { return -.69; } }
    public double ArousalToNonarousal { get { return -.35; } }
    public double DominanceToSubmissiveness { get { return -.33; } }

    public double InnerFocusToOutwardTarget { get { return -.7; } }
}