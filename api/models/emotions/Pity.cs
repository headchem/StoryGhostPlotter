using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Pity : IEmotion
{
    public string Id { get { return "pity"; } }
    public string Name { get { return "Pity"; } }
    public string Description { get { return "Sympathetic sorrow for one suffering, distressed, or unhappy. Feel sorrow for the misfortunes of."; } }
    public List<string> Synonyms { get { return new List<string> { "ache for", "commiserate", "condole", "sympathize", "compassion" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return 0.6; } }
    public double TrustToDisgust { get { return 0.2; } }
    public double FearToAnger { get { return -.2; } }
    public double SurpriseToAnticipation { get { return -.4; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return -.7; } }
    public double TerrorToEnchantment { get { return -.4; } }
    public double HumiliationToPride { get { return -.3; } }

    public double PleasureToDispleasure { get { return .62; } }
    public double ArousalToNonarousal { get { return .11; } }
    public double DominanceToSubmissiveness { get { return .65; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}