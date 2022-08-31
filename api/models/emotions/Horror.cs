using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Horror : IEmotion
{
    public string Id { get { return "horror"; } }
    public string Name { get { return "Horror"; } }
    public string Description { get { return "Filled with fear or dread"; } }
    public List<string> Synonyms { get { return new List<string> { "aghast", "afraid", "spooked", "terrorized", "scared", "mortified" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return .3; } }
    public double TrustToDisgust { get { return .6; } }
    public double FearToAnger { get { return -1.0; } }
    public double SurpriseToAnticipation { get { return -.7; } }

    public double AnxietyToConfidence { get { return -1.0; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return -1.0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .82; } }
    public double ArousalToNonarousal { get { return -.7; } }
    public double DominanceToSubmissiveness { get { return .15; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}