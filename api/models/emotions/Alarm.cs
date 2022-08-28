using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Alarm : IEmotion
{
    public string Id { get { return "alarm"; } }
    public string Name { get { return "Alarm"; } }
    public string Description { get { return "An anxious awareness of danger. Cause (someone) to feel frightened, disturbed, or in danger."; } }
    public List<string> Synonyms { get { return new List<string> { "fear", "anxiety", "trepidation", "unease", "frighten", "startle", "distress" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return -.5; } }
    public double SurpriseToAnticipation { get { return -.8; } }

    public double AnxietyToConfidence { get { return -.7; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return -.8; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .58; } }
    public double ArousalToNonarousal { get { return -.73; } }
    public double DominanceToSubmissiveness { get { return -.18; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}