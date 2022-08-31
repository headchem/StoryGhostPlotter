using StoryGhost.Interfaces;
using StoryGhost.Enums;
using System.Collections.Generic;

namespace StoryGhost.Models.Emotions;

public class Regret : IEmotion
{
    public string Id { get { return "regret"; } }
    public string Name { get { return "Regret"; } }
    public string Description { get { return "Feel sad, repentant, or disappointed over (something that has happened or been done, especially a loss or missed opportunity). To mourn the loss or death of. To miss very much. Sorrow aroused by circumstances beyond one's control or power to repair."; } }
    public List<string> Synonyms { get { return new List<string> { "bemoan", "contrition", "guilt", "remorse", "penitence", "rue", "repentance", "self-reproach" }; } }

    public List<string> Kinds { get { return new List<string> { EmotionKindEnum.EventRelated }; } }

    public double JoyToSadness { get { return .7; } }
    public double TrustToDisgust { get { return 0.2; } }
    public double FearToAnger { get { return 0.4; } }
    public double SurpriseToAnticipation { get { return 0; } }

    public double AnxietyToConfidence { get { return -.5; } }
    public double BoredomToFascination { get { return .3; } }
    public double FrustrationToEuphoria { get { return .7; } }
    public double DispiritedToEncouraged { get { return -1.0; } }
    public double TerrorToEnchantment { get { return -.3; } }
    public double HumiliationToPride { get { return -1.0; } }

    public double PleasureToDispleasure { get { return .56; } }
    public double ArousalToNonarousal { get { return -.03; } }
    public double DominanceToSubmissiveness { get { return .44; } }

    public double InnerFocusToOutwardTarget { get { return -.7; } }
}