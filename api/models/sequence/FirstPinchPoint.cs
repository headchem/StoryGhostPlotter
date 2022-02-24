using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class FirstPinchPoint : ISequence
{
    public string Name { get { return "First Pinch Point"; } }
    public string Description { get { return "Unbeknownst to the Hero, an event demonstrates to the audience how the problem is still looming."; } }

    public AdviceComponents GetAdvice(List<string> genres, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genresList = Factory.GetGenres(genres);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.FirstPinchPoint)),
            ProblemTemplate = problemTemplateObj.AdviceSequence.FirstPinchPoint,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.FirstPinchPoint,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.FirstPinchPoint
        };
    }

}