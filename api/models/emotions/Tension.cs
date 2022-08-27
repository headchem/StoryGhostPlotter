using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Tension : IEmotion
{
    public string Id { get { return "tension"; } }
    public string Name { get { return "Tension"; } }
    public string Description { get { return "Inner striving, unrest, or imbalance often with physiological indication of emotion. A state of latent hostility or opposition between individuals or groups."; } }
    public List<string> Synonyms { get { return new List<string> { "pressure", "strain", "stress", "anxiety" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal, EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .2; } }
    public double FearToAnger { get { return -.1; } }
    public double SurpriseToAnticipation { get { return .5; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .3; } }
    public double ArousalToNonarousal { get { return -.25; } }
    public double DominanceToSubmissiveness { get { return -.18; } }

    public double InnerFocusToOutwardTarget { get { return .3; } }
}