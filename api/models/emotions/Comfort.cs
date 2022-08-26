using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Comfort : IEmotion
{
    public string Id { get { return "comfort"; } }
    public string Name { get { return "Comfort"; } }
    public string Description { get { return "A feeling of ease from grief or trouble"; } }
    public List<string> Synonyms { get { return new List<string> { "solace", "relief" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.4; } }
    public double TrustToDisgust { get { return -.2; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.8; } }
    public double ArousalToNonarousal { get { return .51; } }
    public double DominanceToSubmissiveness { get { return -.18; } }

    public double InnerFocusToOutwardTarget { get { return -.8; } }
}