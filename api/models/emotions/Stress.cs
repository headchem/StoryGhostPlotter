using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Stress : IEmotion
{
    public string Id { get { return "stress"; } }
    public string Name { get { return "Stress"; } }
    public string Description { get { return "A feeling of emotional or physical tension. Bodily or mental tension resulting from factors that tend to alter an existent equilibrium."; } }
    public List<string> Synonyms { get { return new List<string> { "strain", "pressure", "worry", "trouble", "tension", "hectic", "hurried", "frantic", "frazzled" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.SelfAppraisal }; } }

    public double JoyToSadness { get { return .3; } }
    public double TrustToDisgust { get { return .6; } }
    public double FearToAnger { get { return -.6; } }
    public double SurpriseToAnticipation { get { return .7; } }

    public double AnxietyToConfidence { get { return -.7; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return -.1; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return -.5; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .69; } }
    public double ArousalToNonarousal { get { return -.65; } }
    public double DominanceToSubmissiveness { get { return .19; } }

    public double InnerFocusToOutwardTarget { get { return -.5; } }
}