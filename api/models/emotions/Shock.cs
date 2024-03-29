using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Shock : IEmotion
{
    public string Id { get { return "shock"; } }
    public string Name { get { return "Shock"; } }
    public string Description { get { return "To cause someone to feel surprised and upset. A sudden or violent mental or emotional disturbance, event or experience."; } }
    public List<string> Synonyms { get { return new List<string> { "jolt", "offended", "dismayed", "frightened", "surprised" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .1; } }
    public double FearToAnger { get { return -.5; } }
    public double SurpriseToAnticipation { get { return -1.0; } }

    public double AnxietyToConfidence { get { return -1.0; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return -1.0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .27; } }
    public double ArousalToNonarousal { get { return -.69; } }
    public double DominanceToSubmissiveness { get { return -.19; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}