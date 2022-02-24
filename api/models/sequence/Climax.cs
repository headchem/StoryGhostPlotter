using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Climax : ISequence
{
    public string Name { get { return "Climax"; } }
    public string Description { get { return "In a final showdown, the Hero overcomes their weaknesses and shadow side, as they enact their ingenious plan. The Hero incorporates the answer to the Dramatic Question into their fight against the Problem."; } }

    public AdviceComponents GetAdvice(List<string> genres, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genresList = Factory.GetGenres(genres);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Climax)),
            ProblemTemplate = problemTemplateObj.AdviceSequence.Climax,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Climax,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.Climax
        };
    }

}