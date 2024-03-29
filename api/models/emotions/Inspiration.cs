using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Inspiration : IEmotion
{
    public string Id { get { return "inspiration"; } }
    public string Name { get { return "Inspiration"; } }
    public string Description { get { return "The process of being mentally stimulated to do or feel something, especially to do something creative."; } }
    public List<string> Synonyms { get { return new List<string> { "creativity", "inventive", "innovative", "ingenuity" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.5; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return -.1; } }
    public double SurpriseToAnticipation { get { return -.5; } }

    public double AnxietyToConfidence { get { return .7; } }
    public double BoredomToFascination { get { return .9; } }
    public double FrustrationToEuphoria { get { return 1.0; } }
    public double DispiritedToEncouraged { get { return .7; } }
    public double TerrorToEnchantment { get { return 1.0; } }
    public double HumiliationToPride { get { return .4; } }

    public double PleasureToDispleasure { get { return -.88; } }
    public double ArousalToNonarousal { get { return -.32; } }
    public double DominanceToSubmissiveness { get { return -.54; } }

    public double InnerFocusToOutwardTarget { get { return 0; } }
}