using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Confident : IEmotion
{
    public string Id { get { return "confident"; } }
    public string Name { get { return "Confident"; } }
    public string Description { get { return "Having or showing great faith in oneself or one's abilities"; } }
    public List<string> Synonyms { get { return new List<string> { "assured", "secure", "self-asserting", "self-assured" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return -.1; } }
    public double TrustToDisgust { get { return -.5; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.7; } }

    public double AnxietyToConfidence { get { return 1.0; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return .7; } }
    public double DispiritedToEncouraged { get { return .5; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return .7; } }

    public double PleasureToDispleasure { get { return -.72; } }
    public double ArousalToNonarousal { get { return .4; } }
    public double DominanceToSubmissiveness { get { return -.67; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}