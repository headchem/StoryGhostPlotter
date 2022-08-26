using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Attentiveness : IEmotion
{
    public string Id { get { return "attentiveness"; } }
    public string Name { get { return "Attentiveness"; } }
    public string Description { get { return "The action of paying close attention to something. The action of assiduously attending to the comfort or wishes of others; politeness or courtesy."; } }
    public List<string> Synonyms { get { return new List<string> { "heedful", "absorbed", "focused", "immersed", "rapt", "observant" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return -.1; } }
    public double FearToAnger { get { return -.1; } }
    public double SurpriseToAnticipation { get { return 0.6; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.62; } }
    public double ArousalToNonarousal { get { return -.04; } }
    public double DominanceToSubmissiveness { get { return -.45; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}