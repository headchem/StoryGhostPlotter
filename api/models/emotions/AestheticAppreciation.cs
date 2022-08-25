using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class AestheticAppreciation : IEmotion
{
    public string Id { get { return "aesthetic-appreciation"; } }
    public string Name { get { return "Aesthetic Appreciation"; } }
    public string Description { get { return "The extent to which a stimulus is enjoyed because of its beauty or some other factor associated with aesthetic preference."; } }
    public List<string> Synonyms { get { return new List<string> { "moved", "awed" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return -0.7; } }
    public double TrustToDisgust { get { return -.7; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return -.3; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return -.55; } }
    public double ArousalToNonarousal { get { return -0.22; } }
    public double DominanceToSubmissiveness { get { return 0.1; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}