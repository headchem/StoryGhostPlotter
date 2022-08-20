using System;
using System.Collections.Generic;
using StoryGhost.Models;
using StoryGhost.Enums;

namespace StoryGhost.Interfaces;

public interface IEmotion
{
    public string Id { get; } // usually the base emotion name lower-cased
    public string Name { get; }
    public string Description { get; }
    public List<string> Synonyms { get; }

    public string EARLCategory { get; } // Positive thoughts, Positive and lively, Caring, Quiet positive, Negative and not in control, Agitation, Negative and forceful, Negative thoughts, Negative and passive, Reactive
    public string Kind { get; } // Related to object properties, Future appraisal, Event-related, Self-appraisal, Social, Cathected

    // Plutchik

    ///<summary>ecstasy, joy, serenity - pensiveness, sadness, grief</summary>
    public double JoyToSadness { get; }

    ///<summary>admiration, trust, acceptance, boredom, disgust, loathing</summary>
    public double TrustToDisgust { get; }

    ///<summary>terror, fear, apprehension, annoyance, anger, rage</summary>
    public double FearToAnger { get; }

    ///<summary>amazement, surprise, distraction, interest, anticipation, vigilance</summary>
    public double SurpriseToAnticipation { get; }

    // MIT 6 emotion axes

    ///<summary>Anxiety, Worry, Discomfort - Comfort, Hopeful, Confident</summary>
    public double AnxietyToConfidence { get; }

    ///<summary>Ennui, Boredom, Indifference - Interest, Curiosity, Intrigue</summary>
    public double BoredomToFascination { get; }

    ///<summary>Frustration, Puzzlement, Confusion - Insight, Enlightenment, Epiphany</summary>
    public double FrustrationToEuphoria { get; }

    ///<summary>Dispirited, Disappointed, Dissatisfied - Satisfied, Thrilled, Enthusiastic</summary>
    public double DispiritedToEncouraged { get; }

    ///<summary>Terror, Dread, Apprehension - Calm, Anticipatory, Excited</summary>
    public double TerrorToEnchantment { get; }

    ///<summary>Humiliated, Embarrassed, Self-conscious - Pleased, Satisfied, Proud</summary>
    public double HumiliationToPride { get; }

    // VAD/PAD

    ///<summary>The Pleasure-Displeasure Scale measures how pleasant or unpleasant one feels about something. For instance both anger and fear are unpleasant emotions, and both score on the displeasure side. However joy is a pleasant emotion.</summary>
    public double PleasureToDispleasure { get; }

    ///<summary>The Arousal-Nonarousal Scale measures how energized or soporific one feels. It is not the intensity of the emotion -- for grief and depression can be low arousal intense feelings. While both anger and rage are unpleasant emotions, rage has a higher intensity or a higher arousal state. However boredom, which is also an unpleasant state, has a low arousal value.</summary>
    public double ArousalToNonarousal { get; }

    ///<summary>The Dominance-Submissiveness Scale represents the controlling and dominant versus controlled or submissive one feels. For instance while both fear and anger are unpleasant emotions, anger is a dominant emotion, while fear is a submissive emotion.</summary>
    public double DominanceToSubmissiveness { get; }
}