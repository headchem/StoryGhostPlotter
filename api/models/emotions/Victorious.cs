using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Victorious : IEmotion
{
    public string Id { get { return "victorious"; } }
    public string Name { get { return "Victorious"; } }
    public string Description { get { return "Having won a victory; triumphant. Evincing moral harmony or a sense of fulfillment."; } }
    public List<string> Synonyms { get { return new List<string> { "triumphant", "conquering", "vanquishing", "winning", "successful" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated, EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.7; } }
    public double TrustToDisgust { get { return -.7; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.1; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.82; } }
    public double ArousalToNonarousal { get { return -.62; } }
    public double DominanceToSubmissiveness { get { return -.88; } }

    public double InnerFocusToOutwardTarget { get { return .8; } }
}