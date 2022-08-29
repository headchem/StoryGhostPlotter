using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Contentment : IEmotion
{
    public string Id { get { return "contentment"; } }
    public string Name { get { return "Contentment"; } }
    public string Description { get { return "The feeling experienced when one's wishes are met."; } }
    public List<string> Synonyms { get { return new List<string> { "gladness", "pleasure", "satisfaction" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.4; } }
    public double TrustToDisgust { get { return -.2; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .1; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return .3; } }
    public double DispiritedToEncouraged { get { return .5; } }
    public double TerrorToEnchantment { get { return .2; } }
    public double HumiliationToPride { get { return .3; } }

    public double PleasureToDispleasure { get { return -.73; } }
    public double ArousalToNonarousal { get { return -.22; } }
    public double DominanceToSubmissiveness { get { return -.53; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}