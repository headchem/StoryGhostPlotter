using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Demanding : IEmotion
{
    public string Id { get { return "demanding"; } }
    public string Name { get { return "Demanding"; } }
    public string Description { get { return "Making others work hard or meet high standards."; } }
    public List<string> Synonyms { get { return new List<string> { "nagging", "insistent", "clamorous" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 0.1; } }
    public double FearToAnger { get { return 0.2; } }
    public double SurpriseToAnticipation { get { return 0.4; } }

    public double AnxietyToConfidence { get { return 0; } }
    public double BoredomToFascination { get { return .2; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -.4; } }
    public double TerrorToEnchantment { get { return .5; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .31; } }
    public double ArousalToNonarousal { get { return -.42; } }
    public double DominanceToSubmissiveness { get { return -.33; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}