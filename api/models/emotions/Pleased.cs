using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Pleased : IEmotion
{
    public string Id { get { return "pleased"; } }
    public string Name { get { return "Pleased"; } }
    public string Description { get { return "Feeling or showing pleasure and satisfaction, especially at an event or a situation."; } }
    public List<string> Synonyms { get { return new List<string> { "chuffed", "glad", "gratified", "content", "thankful" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.SelfAppraisal }; } }

    public double JoyToSadness { get { return -.5; } }
    public double TrustToDisgust { get { return -.5; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .5; } }

    public double AnxietyToConfidence { get { return .5; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return .5; } }
    public double DispiritedToEncouraged { get { return .7; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return .5; } }

    public double PleasureToDispleasure { get { return -.88; } }
    public double ArousalToNonarousal { get { return -.1; } }
    public double DominanceToSubmissiveness { get { return -.59; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}