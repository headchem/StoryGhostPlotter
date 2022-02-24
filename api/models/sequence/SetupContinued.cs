using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class SetupContinued : ISequence
{
    public string Name { get { return "Setup (Continued)"; } }
    public string Description { get { return "Continue introducing the characters and setting."; } }

    public AdviceComponents GetAdvice(List<string> genres, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genresList = Factory.GetGenres(genres);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.SetupContinued)),
            ProblemTemplate = problemTemplateObj.AdviceSequence.SetupContinued,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.SetupContinued,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.SetupContinued
        };
    }

}