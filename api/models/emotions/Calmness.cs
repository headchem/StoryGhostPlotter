using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Calmness : IEmotion
{
    public string Id { get { return "calmness"; } }
    public string Name { get { return "Calmness"; } }
    public string Description { get { return "The state or quality of being free from agitation, strong emotion, disturbance or violent activity. Evenness of emotions or temper."; } }
    public List<string> Synonyms { get { return new List<string> { "casualness", "easygoingness", "laid-backness", "aplomb", "collected", "composed" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return -.2; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .2; } }

    public double AnxietyToConfidence { get { return .1; } }
    public double BoredomToFascination { get { return -.1; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .2; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return -.8; } }
    public double ArousalToNonarousal { get { return .79; } }
    public double DominanceToSubmissiveness { get { return .31; } }

    public double InnerFocusToOutwardTarget { get { return -.5; } }
}