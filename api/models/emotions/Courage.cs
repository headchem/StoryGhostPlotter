using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Courage : IEmotion
{
    public string Id { get { return "courage"; } }
    public string Name { get { return "Courage"; } }
    public string Description { get { return "Strength of mind to carry on in spite of danger."; } }
    public List<string> Synonyms { get { return new List<string> { "bravery", "daring", "dauntless", "heroism", "moxie", "valor" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.SelfAppraisal }; } }

    public double JoyToSadness { get { return -.7; } }
    public double TrustToDisgust { get { return -.7; } }
    public double FearToAnger { get { return -.7; } }
    public double SurpriseToAnticipation { get { return .7; } }

    public double AnxietyToConfidence { get { return .7; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return .7; } }
    public double TerrorToEnchantment { get { return -.5; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return -.58; } }
    public double ArousalToNonarousal { get { return -.33; } }
    public double DominanceToSubmissiveness { get { return -.62; } }

    public double InnerFocusToOutwardTarget { get { return -.3; } }
}