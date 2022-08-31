using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Outrage : IEmotion
{
    public string Id { get { return "outrage"; } }
    public string Name { get { return "Outrage"; } }
    public string Description { get { return "An extremely strong reaction of anger, shock, or indignation. The anger and resentment aroused by injury or insult"; } }
    public List<string> Synonyms { get { return new List<string> { "indignation", "fury", "anger", "rage", "wrath", "incense", "infuriate" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .5; } }
    public double FearToAnger { get { return 1.0; } }
    public double SurpriseToAnticipation { get { return -1.0; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return -.5; } }
    public double HumiliationToPride { get { return .7; } }

    public double PleasureToDispleasure { get { return .75; } }
    public double ArousalToNonarousal { get { return -.55; } }
    public double DominanceToSubmissiveness { get { return -.2; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}