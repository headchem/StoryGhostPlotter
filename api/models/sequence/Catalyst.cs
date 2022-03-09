using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Catalyst : ISequence
{
    public string Name { get { return "Catalyst"; } }
    public string EventsDescription { get { return "Introduce the Problem through an Inciting Incident that irreversibly shatters the Hero's status quo."; } }
    public string ContextDescription { get { return "The Hero isn't sure what to make of this catalytic event, but it is ultimately what they need to grow."; } }

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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.IncitingIncident)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.IncitingIncident,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.IncitingIncident,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.IncitingIncident
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.IncitingIncident)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.IncitingIncident,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.IncitingIncident,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.IncitingIncident
            },
        };
    }

}