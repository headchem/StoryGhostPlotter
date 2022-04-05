using System;
using System.Collections.Generic;
using System.Linq;
using StoryGhost.Interfaces;
using StoryGhost.Models.Genres;
using StoryGhost.Models.ProblemTemplates;
using StoryGhost.Models.Archetypes;
using StoryGhost.Models.DramaticQuestions;
using StoryGhost.Models.Sequences;
using StoryGhost.Models;


namespace StoryGhost.Util;
public static class PersonalityDescription
{

    public static string GetCharacterPrompt(Character character)
    {
        var personalityDescription = PersonalityDescription.GetDescription(character.Personality);

        var archetypeName = character.Archetype[0].ToString().ToUpper() + character.Archetype.Substring(1);

        return archetypeName + "-type " + character.Name + " is " + personalityDescription;// + CreateFinetuningDataset.PromptSuffix;
    }

    public static string GetDescription(Personality personality)
    {
        double neutral_point = 0.2;

        var closeminded_to_imaginative_desc = getOneWordDesc(neutral_point, personality.ClosemindedToImaginative.Primary, personality.ClosemindedToImaginative.Aspect,
            "a closeminded fuddy duddy", "generally closeminded", "closeminded and mentally resistant",
            "moderate",
            "imaginative and artsy", "generally imaginative", "an imaginative brainstormer");

        var disciplined_to_spontaneous_desc = getOneWordDesc(neutral_point, personality.DisciplinedToSpontaneous.Primary, personality.DisciplinedToSpontaneous.Aspect,
                    "disciplined and industrious", "generally disciplined", "disciplined and orderly",
                    "dynamic",
                    "spontaneous with their head in the clouds", "generally spontaneous", "spontaneous and sloppy");

        var introvert_to_extrovert_desc = getOneWordDesc(neutral_point, personality.IntrovertToExtrovert.Primary, personality.IntrovertToExtrovert.Aspect,
                    "introverted and glum", "generally introverted", "introverted and submissive",
                    "ambivert",
                    "extroverted and gung-ho", "generally extroverted", "extroverted and bossy");

        var cold_to_empathetic_desc = getOneWordDesc(neutral_point, personality.ColdToEmpathetic.Primary, personality.ColdToEmpathetic.Aspect,
                    "cold and unfeeling", "generally cold", "cold and rude",
                    "negotiator",
                    "empathetic and compassionate", "generally empathetic", "empathetic and polite");

        var unflappable_to_anxious_desc = getOneWordDesc(neutral_point, personality.UnflappableToAnxious.Primary, personality.UnflappableToAnxious.Aspect,
                    "unflappable and emotionally impervious", "generally unflappable", "unflappable and relaxed",
                    "responsive to stress",
                    "anxious and volatile", "generally anxious", "anxious and vulnerable");

        return closeminded_to_imaginative_desc + ", " + disciplined_to_spontaneous_desc + ", " + introvert_to_extrovert_desc + ", " + cold_to_empathetic_desc + ", and " + unflappable_to_anxious_desc;
    }

    private static string getOneWordDesc(double neutral_point, double bigFiveAmount, double aspectAmount, string bigFiveNegAspectNeg, string bigFiveNegAspectNeutral, string bigFiveNegAspectPos, string bigFiveTrueNeutral, string bigFivePosAspectNeg, string bigFivePosAspectNeutral, string bigFivePosAspectPos)
    {
        if (bigFiveAmount < neutral_point * -1)
        {
            if (aspectAmount < neutral_point * -1)
            {
                return bigFiveNegAspectNeg;
            }
            else if (aspectAmount > neutral_point)
            {
                return bigFiveNegAspectPos;
            }
            else
            {
                return bigFiveNegAspectNeutral;
            }
        }
        else if (bigFiveAmount > neutral_point)
        {
            if (aspectAmount < neutral_point * -1)
            {
                return bigFivePosAspectNeg;
            }
            else if (aspectAmount > neutral_point)
            {
                return bigFivePosAspectPos;
            }
            else
            {
                return bigFivePosAspectNeutral;
            }
        }
        else
        {
            return bigFiveTrueNeutral;
        }
    }
}
