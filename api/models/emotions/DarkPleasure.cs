using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class DarkPleasure : IEmotion
{
    public string Id { get { return "dark-pleasure"; } }
    public string Name { get { return "Dark Pleasure"; } }
    public string Description { get { return "Deriving pleasure from cruelty."; } }
    public List<string> Synonyms { get { return new List<string> { "glee (at another's expense)", "manaical laughter", "smug", "nefarious" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -1.0; } }
    public double TrustToDisgust { get { return 1.0; } }
    public double FearToAnger { get { return .7; } }
    public double SurpriseToAnticipation { get { return -.4; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return .7; } }
    public double DispiritedToEncouraged { get { return .9; } }
    public double TerrorToEnchantment { get { return .6; } }
    public double HumiliationToPride { get { return 1.0; } }

    public double PleasureToDispleasure { get { return -.7; } }
    public double ArousalToNonarousal { get { return -.7; } }
    public double DominanceToSubmissiveness { get { return -.7; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}