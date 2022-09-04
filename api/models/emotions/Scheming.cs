using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Scheming : IEmotion
{
    public string Id { get { return "scheming"; } }
    public string Name { get { return "Scheming"; } }
    public string Description { get { return "Given to or involved in making secret and underhanded plans."; } }
    public List<string> Synonyms { get { return new List<string> { "sinister", "cunning", "crafty", "devious", "conniving", "wily" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return -.2; } }
    public double TrustToDisgust { get { return -.5; } }
    public double FearToAnger { get { return .5; } }
    public double SurpriseToAnticipation { get { return .8; } }

    public double AnxietyToConfidence { get { return .4; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return .4; } }
    public double DispiritedToEncouraged { get { return 0; } }
    public double TerrorToEnchantment { get { return .4; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return -.4; } }
    public double ArousalToNonarousal { get { return -.5; } }
    public double DominanceToSubmissiveness { get { return -.6; } }

    public double InnerFocusToOutwardTarget { get { return -.3; } }
}