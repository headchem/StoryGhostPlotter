using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Cooldown : ISequence
{
    public string Name { get { return "Cooldown"; } }
    public string EventsDescription { get { return "A bookend to the Opening Image, the Hero demonstrates how they have grown as a person, as they reflect with their team on the ordeal they have survived."; } }
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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.Cooldown)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.Cooldown,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.Cooldown,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.Cooldown
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.Cooldown)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.Cooldown,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.Cooldown,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.Cooldown
            },
        };
    }

}