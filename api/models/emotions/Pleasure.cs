using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Pleasure : IEmotion
{
    public string Id { get { return "pleasure"; } }
    public string Name { get { return "Pleasure"; } }
    public string Description { get { return "A feeling of happy satisfaction and enjoyment."; } }
    public List<string> Synonyms { get { return new List<string> { "happiness", "delight", "joy", "glee", "satisfaction", "content", "enjoyment" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return -.7; } }
    public double TrustToDisgust { get { return -.3; } }
    public double FearToAnger { get { return 0; } }
    public double SurpriseToAnticipation { get { return .4; } }

    public double AnxietyToConfidence { get { return .3; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return .1; } }
    public double DispiritedToEncouraged { get { return .3; } }
    public double TerrorToEnchantment { get { return .3; } }
    public double HumiliationToPride { get { return .5; } }

    public double PleasureToDispleasure { get { return -.86; } }
    public double ArousalToNonarousal { get { return -.28; } }
    public double DominanceToSubmissiveness { get { return -.37; } }

    public double InnerFocusToOutwardTarget { get { return -.5; } }
}