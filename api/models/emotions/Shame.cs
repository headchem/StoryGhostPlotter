using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Shame : IEmotion
{
    public string Id { get { return "shame"; } }
    public string Name { get { return "Shame"; } }
    public string Description { get { return "A painful feeling of humiliation or distress caused by the consciousness of a shortcoming or wrong or foolish behavior. A condition of humiliating disgrace or disrepute."; } }
    public List<string> Synonyms { get { return new List<string> { "contrition", "guilt", "degrade", "humiliate", "remorse", "moritifcation", "loss of face", "embarrassed" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.SelfAppraisal }; } }

    public double JoyToSadness { get { return 0.5; } }
    public double TrustToDisgust { get { return 1.0; } }
    public double FearToAnger { get { return 1.0; } }
    public double SurpriseToAnticipation { get { return 0.7; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return 0; } }
    public double FrustrationToEuphoria { get { return 0; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return -.7; } }
    public double HumiliationToPride { get { return -1.0; } }

    public double PleasureToDispleasure { get { return .75; } }
    public double ArousalToNonarousal { get { return -.32; } }
    public double DominanceToSubmissiveness { get { return .48; } }

    public double InnerFocusToOutwardTarget { get { return -1.0; } }
}