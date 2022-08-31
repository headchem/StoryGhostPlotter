using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Worry : IEmotion
{
    public string Id { get { return "worry"; } }
    public string Name { get { return "Worry"; } }
    public string Description { get { return "Give way to anxiety or unease; allow one's mind to dwell on difficulty or troubles. A state of anxiety and uncertainty over actual or potential problems. To afflict with mental distress or agitation : make anxious."; } }
    public List<string> Synonyms { get { return new List<string> { "fret", "concerned", "anxious", "brood", "distress" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return .3; } }
    public double TrustToDisgust { get { return .1; } }
    public double FearToAnger { get { return -.5; } }
    public double SurpriseToAnticipation { get { return .5; } }

    public double AnxietyToConfidence { get { return -1.0; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return -.7; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return -1.0; } }
    public double HumiliationToPride { get { return -.2; } }

    public double PleasureToDispleasure { get { return 0.76; } }
    public double ArousalToNonarousal { get { return -.51; } }
    public double DominanceToSubmissiveness { get { return .34; } }

    public double InnerFocusToOutwardTarget { get { return .3; } }
}