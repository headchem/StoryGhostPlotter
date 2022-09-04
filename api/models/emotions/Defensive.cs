using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Defensive : IEmotion
{
    public string Id { get { return "defensive"; } }
    public string Name { get { return "Defensive"; } }
    public string Description { get { return "Very anxious to challenge or avoid criticism."; } }
    public List<string> Synonyms { get { return new List<string> { "denial", "self-protective", "prickly", "offended", "oversensitive", "self-justifying", "guarded" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return .5; } }
    public double TrustToDisgust { get { return .5; } }
    public double FearToAnger { get { return .5; } }
    public double SurpriseToAnticipation { get { return -.5; } }

    public double AnxietyToConfidence { get { return -.4; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return -.3; } }
    public double DispiritedToEncouraged { get { return -.6; } }
    public double TerrorToEnchantment { get { return -.3; } }
    public double HumiliationToPride { get { return -.5; } }

    public double PleasureToDispleasure { get { return 0.5; } }
    public double ArousalToNonarousal { get { return -.5; } }
    public double DominanceToSubmissiveness { get { return 0.6; } }

    public double InnerFocusToOutwardTarget { get { return -.7; } }
}