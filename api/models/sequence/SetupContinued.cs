using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class SetupContinued : ISequence
{
    public string Name { get { return "Setup (Continued)"; } }
    public string Description { get { return "Continue introducing the characters and setting."; } }

    public AdviceComponents GetAdvice(string genre, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genreObj = Factory.GetGenre(genre);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genre = genreObj.AdviceSequence.SetupContinued,
            ProblemTemplate = problemTemplateObj.AdviceSequence.SetupContinued,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.SetupContinued,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.SetupContinued
        };
    }

}