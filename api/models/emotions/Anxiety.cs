using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Anxiety : IEmotion
{
    public string Id { get { return "anxiety"; } }
    public string Name { get { return "Anxiety"; } }
    public string Description { get { return "A feeling of worry, nervousness, or unease, typically about an imminent event or something with an uncertain outcome."; } }
    public List<string> Synonyms { get { return new List<string> { "impatience", "concern", "consternation" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return .3; } }
    public double TrustToDisgust { get { return .1; } }
    public double FearToAnger { get { return -1.0; } }
    public double SurpriseToAnticipation { get { return 1.0; } }

    public double AnxietyToConfidence { get { return -1.0; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return -.3; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return -1.0; } }
    public double HumiliationToPride { get { return -.5; } }

    public double PleasureToDispleasure { get { return .56; } }
    public double ArousalToNonarousal { get { return -.7; } }
    public double DominanceToSubmissiveness { get { return .29; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}