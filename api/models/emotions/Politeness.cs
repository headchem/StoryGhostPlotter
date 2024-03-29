using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Politeness : IEmotion
{
    public string Id { get { return "politeness"; } }
    public string Name { get { return "Politeness"; } }
    public string Description { get { return "Marked by an appearance of consideration, tact, deference, or courtesy. Behavior that is respectful and considerate of other people."; } }
    public List<string> Synonyms { get { return new List<string> { "civil", "courteous", "genteel", "mannerly", "respect" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.Social }; } }

    public double JoyToSadness { get { return -.1; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .5; } }

    public double AnxietyToConfidence { get { return .1; } }
    public double BoredomToFascination { get { return -.1; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return .1; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return -.4; } }

    public double PleasureToDispleasure { get { return -.8; } }
    public double ArousalToNonarousal { get { return .27; } }
    public double DominanceToSubmissiveness { get { return -.18; } }

    public double InnerFocusToOutwardTarget { get { return .7; } }
}