using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class FirstPinchPoint : ISequence
{
    public string Name { get { return "First Pinch Point"; } }
    public string EventsDescription { get { return ""; } }
    public string ContextDescription { get { return "Unbeknownst to the Hero, an event demonstrates to the audience how the problem is still looming."; } }

    public AdviceComponentsWrapper GetAdvice(List<string> genres, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genresList = Factory.GetGenres(genres);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponentsWrapper
        {
            Events = new AdviceComponents
            {
                Common = EventsDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.FirstPinchPoint)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.FirstPinchPoint,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.FirstPinchPoint,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.FirstPinchPoint
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.FirstPinchPoint)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.FirstPinchPoint,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.FirstPinchPoint,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.FirstPinchPoint
            },
        };
    }

}