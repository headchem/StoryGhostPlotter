using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Triumph : IEmotion
{
    public string Id { get { return "triumph"; } }
    public string Name { get { return "Triumph"; } }
    public string Description { get { return "A notable success. The joy or exultation of victory or success."; } }
    public List<string> Synonyms { get { return new List<string> { "accomplish", "achieve", "prevail", "conquer", "victorious", "successful" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.8; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.2; } }

    public double AnxietyToConfidence { get { return 1.0; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return 1.0; } }
    public double TerrorToEnchantment { get { return 1.0; } }
    public double HumiliationToPride { get { return 1.0; } }

    public double PleasureToDispleasure { get { return -.92; } }
    public double ArousalToNonarousal { get { return -.64; } }
    public double DominanceToSubmissiveness { get { return -.9; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}