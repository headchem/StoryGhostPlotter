using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class DebateContinued : ISequence
{
    public string Name { get { return "Debate (Continued)"; } }
    public string Description { get { return "The Hero and supporting characters continue debating whether they can tackle the problem."; } }

    public AdviceComponents GetAdvice(string genre, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genreObj = Factory.GetGenre(genre);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genre = genreObj.AdviceSequence.DebateContinued,
            ProblemTemplate = problemTemplateObj.AdviceSequence.DebateContinued,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.DebateContinued,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.DebateContinued
        };
    }

}