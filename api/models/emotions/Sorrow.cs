using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Sorrow : IEmotion
{
    public string Id { get { return "sorrow"; } }
    public string Name { get { return "Sorrow"; } }
    public string Description { get { return "A feeling of deep distress caused by loss, disappointment, or other misfortune suffered by oneself or others. Deep distress, sadness, or regret especially for the loss of someone or something loved."; } }
    public List<string> Synonyms { get { return new List<string> { "anguish", "mourn", "suffer", "grieve", "hurt", "agonize", "sadness", "dejection", "depression", "misery" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 1.0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.5; } }

    public double AnxietyToConfidence { get { return -.3; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return -.5; } }

    public double PleasureToDispleasure { get { return .9; } }
    public double ArousalToNonarousal { get { return .34; } }
    public double DominanceToSubmissiveness { get { return .67; } }

    public double InnerFocusToOutwardTarget { get { return -.5; } }
}