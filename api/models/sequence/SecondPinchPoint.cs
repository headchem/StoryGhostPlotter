using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class SecondPinchPoint : ISequence
{
    public string Name { get { return "Second Pinch Point"; } }
    public string Description { get { return "An event threatening the stakes occurs in plain view of the Hero, who is forced to acknowledge that things don't look good, and appear to be getting worse."; } }

    public AdviceComponents GetAdvice(List<string> genres, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genresList = Factory.GetGenres(genres);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.SecondPinchPoint)),
            ProblemTemplate = problemTemplateObj.AdviceSequence.SecondPinchPoint,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.SecondPinchPoint,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.SecondPinchPoint
        };
    }

}