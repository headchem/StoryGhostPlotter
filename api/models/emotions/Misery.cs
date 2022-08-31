using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Misery : IEmotion
{
    public string Id { get { return "misery"; } }
    public string Name { get { return "Misery"; } }
    public string Description { get { return "A state or feeling of great distress, discomfort, suffering and unhappiness of mind or body."; } }
    public List<string> Synonyms { get { return new List<string> { "agony", "hell", "torment", "nightmare", "distress", "hardship", "suffering" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 1.0; } }
    public double TrustToDisgust { get { return 0.7; } }
    public double FearToAnger { get { return -.3; } }
    public double SurpriseToAnticipation { get { return -.3; } }

    public double AnxietyToConfidence { get { return -.6; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return -.5; } }
    public double HumiliationToPride { get { return -.4; } }

    public double PleasureToDispleasure { get { return 0.67; } }
    public double ArousalToNonarousal { get { return 0.08; } }
    public double DominanceToSubmissiveness { get { return 0.67; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}