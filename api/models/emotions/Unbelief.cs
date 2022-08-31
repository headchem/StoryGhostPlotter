using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Unbelief : IEmotion
{
    public string Id { get { return "unbelief"; } }
    public string Name { get { return "Unbelief"; } }
    public string Description { get { return "Incredulity or skepticism. An absence of faith."; } }
    public List<string> Synonyms { get { return new List<string> { "incredulity", "skepticism" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return .1; } }
    public double TrustToDisgust { get { return .1; } }
    public double FearToAnger { get { return -.1; } }
    public double SurpriseToAnticipation { get { return -.7; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return 1.0; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return -.4; } }
    public double TerrorToEnchantment { get { return -.2; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return -.04; } }
    public double ArousalToNonarousal { get { return -.37; } }
    public double DominanceToSubmissiveness { get { return -.12; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}