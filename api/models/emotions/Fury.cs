using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Fury : IEmotion
{
    public string Id { get { return "fury"; } }
    public string Name { get { return "Fury"; } }
    public string Description { get { return "Wild or violent anger. Violence or energy displayed in natural phenomena or in someone's actions."; } }
    public List<string> Synonyms { get { return new List<string> { "rage", "wrath", "outrage", "ferocity", "fierceness" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .5; } }
    public double FearToAnger { get { return 1.0; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .88; } }
    public double ArousalToNonarousal { get { return -.84; } }
    public double DominanceToSubmissiveness { get { return -.29; } }

    public double InnerFocusToOutwardTarget { get { return 1.0; } }
}