using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Midpoint : ISequence
{
    public string Name { get { return "Midpoint"; } }
    public string EventsDescription { get { return "Hidden info about the Problem or a character is revealed, recontextualizing the situation, further raising the stakes for the Hero. The Hero, or their perfectly in sync team, wins a victory, but a negative twist makes it a hollow victory."; } }
    public string ContextDescription { get { return "The Hero's flaws are still present - only temporarily masked."; } }

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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.Midpoint)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.Midpoint,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.Midpoint,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.Midpoint
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.Midpoint)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.Midpoint,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.Midpoint,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.Midpoint
            },
        };
    }

}