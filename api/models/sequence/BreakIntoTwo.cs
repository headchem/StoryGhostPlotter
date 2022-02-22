using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class BreakIntoTwo : ISequence
{
    public string Name { get { return "Break Into Two"; } }
    public string Description { get { return "Another event further enhances the Problem. The Hero is done debating - they choose to act! They take their first steps into an upside-down world."; } }

    public AdviceComponents GetAdvice(string genre, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genreObj = Factory.GetGenre(genre);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genre = genreObj.AdviceSequence.BreakIntoTwo,
            ProblemTemplate = problemTemplateObj.AdviceSequence.BreakIntoTwo,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.BreakIntoTwo,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.BreakIntoTwo
        };
    }

}