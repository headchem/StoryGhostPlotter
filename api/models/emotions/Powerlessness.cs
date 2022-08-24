using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Powerlessness : IEmotion
{
    public string Id { get { return "powerlessness"; } }
    public string Name { get { return "Powerlessness"; } }
    public string Description { get { return ""; } }
    public List<string> Synonyms { get { return new List<string> { }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return .7; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return -.3; } }
    public double SurpriseToAnticipation { get { return .7; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .75; } }
    public double ArousalToNonarousal { get { return 0.5; } }
    public double DominanceToSubmissiveness { get { return 0.34; } }

    public double InnerFocusToOutwardTarget { get { return -.5; } }
}