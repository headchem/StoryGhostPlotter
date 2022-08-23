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

    ///<summary>Refer to: https://en.wikipedia.org/wiki/Emotion_classification#Contrasting_basic_emotions</summary>
    public List<string> Kinds { get; } // Related to object properties, Future appraisal, Event-related, Self-appraisal, Social, Cathected

    // Plutchik

    ///<summary>ecstasy, joy, serenity - pensiveness, sadness, grief</summary>
    public double JoyToSadness { get; }

    ///<summary>admiration, trust, acceptance, boredom, disgust, loathing</summary>
    public double TrustToDisgust { get; }

    ///<summary>terror, fear, apprehension, annoyance, anger, rage</summary>
    public double FearToAnger { get; }

    ///<summary>amazement, surprise, distraction, interest, anticipation, vigilance</summary>
    public double SurpriseToAnticipation { get; }

    // MIT 6 emotion axes (seem focused on learning-related emotions, consider dropping? But learning in everyday life is important, so maybe our emotions in screenplay scenes are useful to "learn" how people behave, or to help us navigate interesting situations)

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

    ///<summary>The Dominance-Submissiveness Scale represents the controlling and dominant versus controlled by/reactive or submissive one feels. For instance while both fear and anger are unpleasant emotions, anger is a dominant emotion, while fear is a submissive emotion. Are you driving the emotion (dominant) or is the emotion happening to you (submissive)?
    ///</summary>
    public double DominanceToSubmissiveness { get; }

    // HUMAINE's proposal for EARL: The emotion annotation and representation language (EARL) proposed by the Human-Machine Interaction Network on Emotion (HUMAINE) classifies 48 emotions.

    ///<summary>
    /// Inner thoughts/focus examples: pride, doubt, envy, frustration, guilt, shame, courage, hope, humility, satisfaction, trust<br/>
    /// Outward target examples: surprise, interest, polieness, anger, annoyance, contempt, dusgust, irritation, amusement, delight, elation, excitement, happiness, joy, pleasure, empathy, friendliness, love
    ///</summary>
    public double InnerFocusToOutwardTarget { get; }

}