using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class FirstPinchPoint : ISequence
{
    public string Name { get { return "First Pinch Point"; } }
    public string Description { get { return "Unbeknownst to the Hero, an event demonstrates to the audience how the problem is still looming."; } }

    public AdviceComponents GetAdvice(string genre, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genreObj = Factory.GetGenre(genre);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genre = genreObj.AdviceSequence.FirstPinchPoint,
            ProblemTemplate = problemTemplateObj.AdviceSequence.FirstPinchPoint,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.FirstPinchPoint,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.FirstPinchPoint
        };
    }

}