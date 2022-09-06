using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Learning : IEmotion
{
    public string Id { get { return "learning"; } }
    public string Name { get { return "Learning"; } }
    public string Description { get { return "the acquisition of knowledge or skills through experience, study, or by being taught."; } }
    public List<string> Synonyms { get { return new List<string> { "studying", "attentive", "paying attention", "keeping an eye on", "taught", "educate" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.5; } }
    public double TrustToDisgust { get { return -.7; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return 0.5; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return 1.0; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return .2; } }
    public double TerrorToEnchantment { get { return .5; } }
    public double HumiliationToPride { get { return .4; } }

    public double PleasureToDispleasure { get { return -.49; } }
    public double ArousalToNonarousal { get { return -.01; } }
    public double DominanceToSubmissiveness { get { return -.24; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}