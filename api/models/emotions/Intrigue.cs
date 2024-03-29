using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Intrigue : IEmotion
{
    public string Id { get { return "intrigue"; } }
    public string Name { get { return "Intrigue"; } }
    public string Description { get { return "Arouse the curiosity or interest of; fascinate."; } }
    public List<string> Synonyms { get { return new List<string> { "curious", "fascinate", "mysterious" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated, EmotionKindEnum.RelatedToObjectProperties }; } }

    public double JoyToSadness { get { return -.2; } }
    public double TrustToDisgust { get { return -.2; } }
    public double FearToAnger { get { return -.1; } }
    public double SurpriseToAnticipation { get { return -.4; } }

    public double AnxietyToConfidence { get { return 0; } }
    public double BoredomToFascination { get { return .7; } }
    public double FrustrationToEuphoria { get { return -.5; } }
    public double DispiritedToEncouraged { get { return .2; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .22; } }
    public double ArousalToNonarousal { get { return -.54; } }
    public double DominanceToSubmissiveness { get { return .21; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}