using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Relief : IEmotion
{
    public string Id { get { return "relief"; } }
    public string Name { get { return "Relief"; } }
    public string Description { get { return "A feeling of reassurance and relaxation following release from anxiety or distress. Removal or lightening of something oppressive, painful, or distressing."; } }
    public List<string> Synonyms { get { return new List<string> { "comfort", "relaxation", "solace" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.3; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.65; } }
    public double ArousalToNonarousal { get { return .48; } }
    public double DominanceToSubmissiveness { get { return 0.07; } }

    public double InnerFocusToOutwardTarget { get { return -.8; } }
}