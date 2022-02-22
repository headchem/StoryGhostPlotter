using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class BreakIntoThree : ISequence
{
    public string Name { get { return "Break Into Three"; } }
    public string Description { get { return "The Hero answers the Dramatic Question with lessons learned from the characters in the subplot. The Hero's recent Ego Death is synthesized with a final injection of hidden information to reveal the key to defeat the Problem. But a new twist threatens all! The Hero plans one last desperate attempt to defeat the Problem."; } }

    public AdviceComponents GetAdvice(string genre, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genreObj = Factory.GetGenre(genre);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genre = genreObj.AdviceSequence.BreakIntoThree,
            ProblemTemplate = problemTemplateObj.AdviceSequence.BreakIntoThree,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.BreakIntoThree,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.BreakIntoThree
        };
    }

}