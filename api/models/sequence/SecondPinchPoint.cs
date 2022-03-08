using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class SecondPinchPoint : ISequence
{
    public string Name { get { return "Second Pinch Point"; } }
    public string EventsDescription { get { return "An event threatening the stakes occurs in plain view of the Hero, who is forced to acknowledge that things don't look good, and appear to be getting worse."; } }
    public string ContextDescription { get { return ""; } }

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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.SecondPinchPoint)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.SecondPinchPoint,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.SecondPinchPoint,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.SecondPinchPoint
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.SecondPinchPoint)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.SecondPinchPoint,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.SecondPinchPoint,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.SecondPinchPoint
            },
        };
    }

}