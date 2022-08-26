using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Discomfort : IEmotion
{
    public string Id { get { return "discomfort"; } }
    public string Name { get { return "Discomfort"; } }
    public string Description { get { return "To trouble the mind of; to make uneasy."; } }
    public List<string> Synonyms { get { return new List<string> { "agitate", "bother", "disquiet", "frazzle", "unsettle" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return 0.2; } }
    public double TrustToDisgust { get { return 0.1; } }
    public double FearToAnger { get { return 0.1; } }
    public double SurpriseToAnticipation { get { return -.2; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .69; } }
    public double ArousalToNonarousal { get { return -.44; } }
    public double DominanceToSubmissiveness { get { return .46; } }

    public double InnerFocusToOutwardTarget { get { return 0; } }
}