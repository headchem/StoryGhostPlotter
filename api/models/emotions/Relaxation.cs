using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Relaxation : IEmotion
{
    public string Id { get { return "relaxation"; } }
    public string Name { get { return "Relaxation"; } }
    public string Description { get { return "The state of being free from tension and anxiety. A relaxing or recreative state, activity, or pastime."; } }
    public List<string> Synonyms { get { return new List<string> { "recreation", "dalliance", "frolic", "calm", "tranquility", "peacefulness", "repose", "easiness" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.2; } }
    public double TrustToDisgust { get { return -.2; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .7; } }
    public double BoredomToFascination { get { return -.1; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return .2; } }

    public double PleasureToDispleasure { get { return -.76; } }
    public double ArousalToNonarousal { get { return .67; } }
    public double DominanceToSubmissiveness { get { return .19; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}