using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Vengeance : IEmotion
{
    public string Id { get { return "vengeance"; } }
    public string Name { get { return "Vengeance"; } }
    public string Description { get { return "Punishment inflicted or retribution exacted for an injury, wrong or offense."; } }
    public List<string> Synonyms { get { return new List<string> { "payback", "retaliation", "revenge", "retribution", "avengement" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.7; } }
    public double TrustToDisgust { get { return .5; } }
    public double FearToAnger { get { return .8; } }
    public double SurpriseToAnticipation { get { return .8; } }

    public double AnxietyToConfidence { get { return .6; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return .5; } }
    public double DispiritedToEncouraged { get { return 1.0; } }
    public double TerrorToEnchantment { get { return 1.0; } }
    public double HumiliationToPride { get { return 1.0; } }

    public double PleasureToDispleasure { get { return .79; } }
    public double ArousalToNonarousal { get { return -.85; } }
    public double DominanceToSubmissiveness { get { return -.44; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}