using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Amusement : IEmotion
{
    public string Id { get { return "amusement"; } }
    public string Name { get { return "Amusement"; } }
    public string Description { get { return "The state or experience of finding something funny."; } }
    public List<string> Synonyms { get { return new List<string> { "mirth", "merriment", "light-heartedness", "glee" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.2; } }
    public double TrustToDisgust { get { return -.1; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .1; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return .7; } }
    public double DispiritedToEncouraged { get { return .2; } }
    public double TerrorToEnchantment { get { return .4; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return -.82; } }
    public double ArousalToNonarousal { get { return -.6; } }
    public double DominanceToSubmissiveness { get { return -.35; } }

    public double InnerFocusToOutwardTarget { get { return .3; } }
}