using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Attraction : IEmotion
{
    public string Id { get { return "attraction"; } }
    public string Name { get { return "Attraction"; } }
    public string Description { get { return "The action or power of evoking interest, pleasure, or liking for someone or something."; } }
    public List<string> Synonyms { get { return new List<string> { "appeal", "desireability", "seductivenss", "allure", "infatuated" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return -.3; } }
    public double TrustToDisgust { get { return -.2; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.3; } }

    public double AnxietyToConfidence { get { return 0; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .5; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return -.77; } }
    public double ArousalToNonarousal { get { return -.37; } }
    public double DominanceToSubmissiveness { get { return -.5; } }

    public double InnerFocusToOutwardTarget { get { return .8; } }
}