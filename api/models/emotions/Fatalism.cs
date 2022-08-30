using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Fatalism : IEmotion
{
    public string Id { get { return "fatalism"; } }
    public string Name { get { return "Fatalism"; } }
    public string Description { get { return "The belief that all events are predetermined and therefore inevitable. A doctrine that events are fixed in advance so that human beings are powerless to change them."; } }
    public List<string> Synonyms { get { return new List<string> { "resignation", "defeatist", "nihilstic", "pessimistic", "grim" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.FutureAppraisal }; } }

    public double JoyToSadness { get { return .5; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .8; } }

    public double AnxietyToConfidence { get { return .5; } }
    public double BoredomToFascination { get { return -.5; } }
    public double FrustrationToEuphoria { get { return .5; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return .2; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .58; } }
    public double ArousalToNonarousal { get { return -.39; } }
    public double DominanceToSubmissiveness { get { return -.26; } }

    public double InnerFocusToOutwardTarget { get { return 0; } }
}