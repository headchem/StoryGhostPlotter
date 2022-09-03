using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Timid : IEmotion
{
    public string Id { get { return "timid"; } }
    public string Name { get { return "Timid"; } }
    public string Description { get { return "Careful to avoid potential problems or dangers.. showing a lack of courage or confidence; easily frightened."; } }
    public List<string> Synonyms { get { return new List<string> { "cautious", "wary", "heedful", "attentive", "alert", "watchful", "vigilant", "careful" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return .1; } }
    public double TrustToDisgust { get { return 0; } }
    public double FearToAnger { get { return -.6; } }
    public double SurpriseToAnticipation { get { return 1.0; } }

    public double AnxietyToConfidence { get { return -.4; } }
    public double BoredomToFascination { get { return .4; } }
    public double FrustrationToEuphoria { get { return -.1; } }
    public double DispiritedToEncouraged { get { return -.2; } }
    public double TerrorToEnchantment { get { return -.5; } }
    public double HumiliationToPride { get { return 0; } }

    public double PleasureToDispleasure { get { return .14; } }
    public double ArousalToNonarousal { get { return .28; } }
    public double DominanceToSubmissiveness { get { return .26; } }

    public double InnerFocusToOutwardTarget { get { return 0.7; } }
}