using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class BreakIntoTwo : ISequence
{
    public string Name { get { return "Break Into Two"; } }
    public string EventsDescription { get { return "Another event further enhances the Problem. The Hero is done debating - they choose to act! They take their first steps into an upside-down world."; } }
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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.BreakIntoTwo)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.BreakIntoTwo,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.BreakIntoTwo,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.BreakIntoTwo
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.BreakIntoTwo)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.BreakIntoTwo,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.BreakIntoTwo,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.BreakIntoTwo
            },
        };
    }

}