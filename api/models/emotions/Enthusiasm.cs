using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Enthusiasm : IEmotion
{
    public string Id { get { return "enthusiasm"; } }
    public string Name { get { return "Enthusiasm"; } }
    public string Description { get { return "Urgent desire or interest"; } }
    public List<string> Synonyms { get { return new List<string> { "ardor", "avid", "eagerness", "keenness" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal, EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.6; } }
    public double TrustToDisgust { get { return -.4; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .1; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.82; } }
    public double ArousalToNonarousal { get { return -.68; } }
    public double DominanceToSubmissiveness { get { return -.65; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}