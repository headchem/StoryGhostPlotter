using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Hectic : IEmotion
{
    public string Id { get { return "hectic"; } }
    public string Name { get { return "Hectic"; } }
    public string Description { get { return "Full of incessant or frantic activity. Characterized by activity, excitement, or confusion."; } }
    public List<string> Synonyms { get { return new List<string> { "stress", "pressure", "tension", "hectic", "hurried", "frantic", "frazzled", "frenzied", "frenetic", "busy" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return .3; } }
    public double TrustToDisgust { get { return .3; } }
    public double FearToAnger { get { return -.3; } }
    public double SurpriseToAnticipation { get { return .7; } }

    public double AnxietyToConfidence { get { return -.8; } }
    public double BoredomToFascination { get { return .6; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return -.7; } }
    public double HumiliationToPride { get { return -.3; } }

    public double PleasureToDispleasure { get { return .45; } }
    public double ArousalToNonarousal { get { return -.51; } }
    public double DominanceToSubmissiveness { get { return -0.07; } }

    public double InnerFocusToOutwardTarget { get { return -.7; } }
}