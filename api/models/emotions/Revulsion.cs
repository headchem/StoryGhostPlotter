using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Revulsion : IEmotion
{
    public string Id { get { return "revulsion"; } }
    public string Name { get { return "Revulsion"; } }
    public string Description { get { return "A sense of utter distaste, disgust, loathing or repugnance. A strong pulling or drawing away."; } }
    public List<string> Synonyms { get { return new List<string> { "disgust", "repulsion", "abhorrence", "repugnance", "loathing", "nausea" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return 1.0; } }
    public double FearToAnger { get { return .8; } }
    public double SurpriseToAnticipation { get { return -.8; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return -.5; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .79; } }
    public double ArousalToNonarousal { get { return -.53; } }
    public double DominanceToSubmissiveness { get { return .31; } }

    public double InnerFocusToOutwardTarget { get { return .8; } }
}