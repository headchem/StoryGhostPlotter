using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class BStory : ISequence
{
    public string Name { get { return "B Story"; } }
    public string Description { get { return "The B Story is usually the love story set against the backdrop of the main action."; } }

    public AdviceComponents GetAdvice(List<string> genres, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genresList = Factory.GetGenres(genres);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.BStory)),
            ProblemTemplate = problemTemplateObj.AdviceSequence.BStory,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.BStory,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.BStory
        };
    }

}