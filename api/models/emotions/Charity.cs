using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Charity : IEmotion
{
    public string Id { get { return "charity"; } }
    public string Name { get { return "Charity"; } }
    public string Description { get { return "Kind, gentle, or compassionate treatment especially towards someone who is undeserving of it. The giving of necessities and especially money to the needy"; } }
    public List<string> Synonyms { get { return new List<string> { "philanthropy", "benevolence", "bestowal" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.3; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.5; } }

    public double AnxietyToConfidence { get { return .5; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return .5; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return .7; } }

    public double PleasureToDispleasure { get { return -.79; } }
    public double ArousalToNonarousal { get { return .34; } }
    public double DominanceToSubmissiveness { get { return -.14; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}