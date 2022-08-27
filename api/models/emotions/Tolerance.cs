using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Tolerance : IEmotion
{
    public string Id { get { return "tolerance"; } }
    public string Name { get { return "Tolerance"; } }
    public string Description { get { return "Capacity to endure pain or hardship. The ability or willingness to tolerate something, in particular the existence of opinions or behavior that one does not necessarily agree with."; } }
    public List<string> Synonyms { get { return new List<string> { "long-suffering", "patience", "forbearance", "open-mindedness" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return -.2; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.2; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.64; } }
    public double ArousalToNonarousal { get { return .6; } }
    public double DominanceToSubmissiveness { get { return -.27; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}