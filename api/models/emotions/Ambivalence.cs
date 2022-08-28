using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Ambivalence : IEmotion
{
    public string Id { get { return "ambivalence"; } }
    public string Name { get { return "Ambivalence"; } }
    public string Description { get { return "The state of having mixed feelings or contradictory ideas about something or someone."; } }
    public List<string> Synonyms { get { return new List<string> { "equivocation", "uncertainty", "unsureness", "indecision" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return -.2; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .2; } }

    public double AnxietyToConfidence { get { return 0; } }
    public double BoredomToFascination { get { return -.5; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -.2; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return -.02; } }
    public double ArousalToNonarousal { get { return .19; } }
    public double DominanceToSubmissiveness { get { return 0.04; } }

    public double InnerFocusToOutwardTarget { get { return -0.05; } }
}