using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Frustration : IEmotion
{
    public string Id { get { return "frustration"; } }
    public string Name { get { return "Frustration"; } }
    public string Description { get { return "The feeling of being upset or annoyed, especially because of inability to change or achieve something."; } }
    public List<string> Synonyms { get { return new List<string> { "exasperation", "irritation", "thwarted" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return 0; } }
    public double TrustToDisgust { get { return .5; } }
    public double FearToAnger { get { return .5; } }
    public double SurpriseToAnticipation { get { return -.3; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return -.1; } }
    public double HumiliationToPride { get { return -.7; } }

    public double PleasureToDispleasure { get { return .83; } }
    public double ArousalToNonarousal { get { return -.42; } }
    public double DominanceToSubmissiveness { get { return .45; } }

    public double InnerFocusToOutwardTarget { get { return .6; } }
}