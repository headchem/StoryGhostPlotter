using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Guilt : IEmotion
{
    public string Id { get { return "guilt"; } }
    public string Name { get { return "Guilt"; } }
    public string Description { get { return "A feeling of responsibility for wrongdoing."; } }
    public List<string> Synonyms { get { return new List<string> { "contrition", "penitence", "regret", "remorse", "repentance", "rue", "shame" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social, EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0.5; } }
    public double TrustToDisgust { get { return 0.5; } }
    public double FearToAnger { get { return 0.5; } }
    public double SurpriseToAnticipation { get { return -.2; } }

    public double AnxietyToConfidence { get { return -1.0; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return -.3; } }
    public double DispiritedToEncouraged { get { return -.7; } }
    public double TerrorToEnchantment { get { return -.3; } }
    public double HumiliationToPride { get { return -1.0; } }

    public double PleasureToDispleasure { get { return 0.66; } }
    public double ArousalToNonarousal { get { return -.34; } }
    public double DominanceToSubmissiveness { get { return 0.44; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}