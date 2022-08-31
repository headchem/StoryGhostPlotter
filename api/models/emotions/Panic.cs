using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Panic : IEmotion
{
    public string Id { get { return "panic"; } }
    public string Name { get { return "Panic"; } }
    public string Description { get { return "Sudden uncontrollable fear or anxiety, often causing wildly unthinking behavior. A sudden overpowering fright. A sudden unreasoning terror often accompanied by mass flight."; } }
    public List<string> Synonyms { get { return new List<string> { "alarm", "anxiety", "fear", "fright", "scare", "shock", "startle", "terrify" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return .1; } }
    public double TrustToDisgust { get { return .1; } }
    public double FearToAnger { get { return -1.0; } }
    public double SurpriseToAnticipation { get { return -1.0; } }

    public double AnxietyToConfidence { get { return -1.0; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return -1.0; } }
    public double DispiritedToEncouraged { get { return -.5; } }
    public double TerrorToEnchantment { get { return -1.0; } }
    public double HumiliationToPride { get { return -.3; } }

    public double PleasureToDispleasure { get { return .73; } }
    public double ArousalToNonarousal { get { return -.87; } }
    public double DominanceToSubmissiveness { get { return .31; } }

    public double InnerFocusToOutwardTarget { get { return .5; } }
}