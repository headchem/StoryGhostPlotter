using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Jealousy : IEmotion
{
    public string Id { get { return "jealousy"; } }
    public string Name { get { return "Jealousy"; } }
    public string Description { get { return "Jealousy generally refers to the thoughts or feelings of insecurity, fear, and concern over a relative lack of possessions or safety."; } }
    public List<string> Synonyms { get { return new List<string> { "envy", "bitterness" }; } }

    public string EARLCategory
    {
        get
        {
            return EARLCategoryEnum.NegativeThoughts;
        }
    }
    public string Kind
    {
        get
        {
            return EmotionKindEnum.Social;
        }
    }

    public double JoyToSadness { get { return .33; } }
    public double TrustToDisgust { get { return .66; } }
    public double FearToAnger { get { return .66; } }
    public double SurpriseToAnticipation { get { return -.33; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .5; } }
    public double FrustrationToEuphoria { get { return -.66; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return 0; } }
    public double HumiliationToPride { get { return -.5; } }

    public double PleasureToDispleasure { get { return 1.0; } }
    public double ArousalToNonarousal { get { return -.33; } }
    public double DominanceToSubmissiveness { get { return -.33; } }
}