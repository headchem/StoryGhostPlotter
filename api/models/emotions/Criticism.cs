using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Criticism : IEmotion
{
    public string Id { get { return "criticism"; } }
    public string Name { get { return "Criticism"; } }
    public string Description { get { return "The expression of disapproval of someone or something based on perceived faults or mistakes."; } }
    public List<string> Synonyms { get { return new List<string> { "censure", "condemnation", "denunciation" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0.1; } }
    public double TrustToDisgust { get { return 0.4; } }
    public double FearToAnger { get { return 0.2; } }
    public double SurpriseToAnticipation { get { return -.2; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return 0.65; } }
    public double ArousalToNonarousal { get { return -.35; } }
    public double DominanceToSubmissiveness { get { return .09; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}