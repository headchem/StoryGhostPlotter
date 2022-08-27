using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Puzzlement : IEmotion
{
    public string Id { get { return "puzzlement"; } }
    public string Name { get { return "Puzzlement"; } }
    public string Description { get { return "A feeling of confusion through lack of understanding."; } }
    public List<string> Synonyms { get { return new List<string> { "baffle", "addle", "bamboozle", "befuddle", "bewilder", "confound", "confuse", "discombobulate", "disorient", "flummox", "muddle", "mystify", "perplex" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.2; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return -.2; } }
    public double SurpriseToAnticipation { get { return -.7; } }

    public double AnxietyToConfidence { get { return .1111111; } }
    public double BoredomToFascination { get { return .1111111; } }
    public double FrustrationToEuphoria { get { return .1111111; } }
    public double DispiritedToEncouraged { get { return .1111111; } }
    public double TerrorToEnchantment { get { return .1111111; } }
    public double HumiliationToPride { get { return .1111111; } }

    public double PleasureToDispleasure { get { return .31; } }
    public double ArousalToNonarousal { get { return -.08; } }
    public double DominanceToSubmissiveness { get { return .23; } }

    public double InnerFocusToOutwardTarget { get { return .8; } }
}