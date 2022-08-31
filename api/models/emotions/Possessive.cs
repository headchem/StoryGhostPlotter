using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Possessive : IEmotion
{
    public string Id { get { return "possessive"; } }
    public string Name { get { return "Possessive"; } }
    public string Description { get { return "Demanding someone's total attention and love."; } }
    public List<string> Synonyms { get { return new List<string> { "overprotective", "clinging", "dominating", "controlling" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .2; } }
    public double FearToAnger { get { return -.7; } }
    public double SurpriseToAnticipation { get { return .5; } }

    public double AnxietyToConfidence { get { return -.7; } }
    public double BoredomToFascination { get { return .7; } }
    public double FrustrationToEuphoria { get { return -.4; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return -.7; } }
    public double HumiliationToPride { get { return .8; } }

    public double PleasureToDispleasure { get { return .44; } }
    public double ArousalToNonarousal { get { return -.3; } }
    public double DominanceToSubmissiveness { get { return -.39; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}