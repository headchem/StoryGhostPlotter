using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Insecurity : IEmotion
{
    public string Id { get { return "insecurity"; } }
    public string Name { get { return "Insecurity"; } }
    public string Description { get { return "A state or feeling of anxiety, fear, or self-doubt"; } }
    public List<string> Synonyms { get { return new List<string> { "doubt", "lack of self-confidence", "self-doubt", "inferior", "inadequate", "intimidated" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.SelfAppraisal }; } }

    public double JoyToSadness { get { return 0.7; } }
    public double TrustToDisgust { get { return .7; } }
    public double FearToAnger { get { return -.7; } }
    public double SurpriseToAnticipation { get { return .5; } }

    public double AnxietyToConfidence { get { return -.7; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return -.3; } }
    public double DispiritedToEncouraged { get { return -.7; } }
    public double TerrorToEnchantment { get { return -.4; } }
    public double HumiliationToPride { get { return -.4; } }

    public double PleasureToDispleasure { get { return .79; } }
    public double ArousalToNonarousal { get { return -.19; } }
    public double DominanceToSubmissiveness { get { return .52; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}