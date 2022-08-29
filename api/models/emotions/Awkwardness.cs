using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Awkwardness : IEmotion
{
    public string Id { get { return "awkwardness"; } }
    public string Name { get { return "Awkwardness"; } }
    public string Description { get { return "Lacking skill or dexterity. Lacking skill or dexterity. Lacking social graces or manners."; } }
    public List<string> Synonyms { get { return new List<string> { "embarrassment", "self-consciousness", "uncoordinated", "graceless", "clumsy", "unwieldy" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return .3; } }
    public double TrustToDisgust { get { return .2; } }
    public double FearToAnger { get { return -.2; } }
    public double SurpriseToAnticipation { get { return -.3; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -.3; } }
    public double TerrorToEnchantment { get { return -.3; } }
    public double HumiliationToPride { get { return -.7; } }

    public double PleasureToDispleasure { get { return 0.54; } }
    public double ArousalToNonarousal { get { return -.1; } }
    public double DominanceToSubmissiveness { get { return .49; } }

    public double InnerFocusToOutwardTarget { get { return -.7; } }
}