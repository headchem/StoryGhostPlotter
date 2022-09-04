using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Pleading : IEmotion
{
    public string Id { get { return "pleading"; } }
    public string Name { get { return "Pleading"; } }
    public string Description { get { return "The action of making an emotional or earnest appeal to someone."; } }
    public List<string> Synonyms { get { return new List<string> { "begging", "desperate", "beseech", "implore", "petition", "request" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 1.0; } }
    public double TrustToDisgust { get { return .8; } }
    public double FearToAnger { get { return -.8; } }
    public double SurpriseToAnticipation { get { return .9; } }

    public double AnxietyToConfidence { get { return -.7; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return -.7; } }
    public double TerrorToEnchantment { get { return -.8; } }
    public double HumiliationToPride { get { return -.7; } }

    public double PleasureToDispleasure { get { return 0.8; } }
    public double ArousalToNonarousal { get { return -.7; } }
    public double DominanceToSubmissiveness { get { return 0.8; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}