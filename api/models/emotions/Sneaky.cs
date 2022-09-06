using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Sneaky : IEmotion
{
    public string Id { get { return "sneaky"; } }
    public string Name { get { return "Sneaky"; } }
    public string Description { get { return "(of a feeling) secret; reluctant; furtive; sly"; } }
    public List<string> Synonyms { get { return new List<string> { "clever", "tricky", "sly", "mischievous" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.5; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .7; } }

    public double AnxietyToConfidence { get { return .5; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .5; } }
    public double HumiliationToPride { get { return .7; } }

    public double PleasureToDispleasure { get { return -.4; } }
    public double ArousalToNonarousal { get { return 0.2; } }
    public double DominanceToSubmissiveness { get { return -.7; } }

    public double InnerFocusToOutwardTarget { get { return 0.7; } }
}