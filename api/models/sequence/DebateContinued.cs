using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class DebateContinued : ISequence
{
    public string Name { get { return "Debate (Continued)"; } }
    public string EventsDescription { get { return "The Hero and supporting characters continue debating whether they can tackle the problem."; } }
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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.DebateContinued)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.DebateContinued,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.DebateContinued,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.DebateContinued
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.DebateContinued)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.DebateContinued,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.DebateContinued,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.DebateContinued
            },
        };
    }

}