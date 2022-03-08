using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class BStory : ISequence
{
    public string Name { get { return "B Story"; } }
    public string EventsDescription { get { return "The B Story is usually the love story set against the backdrop of the main action."; } }
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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.BStory)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.BStory,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.BStory,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.BStory
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.BStory)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.BStory,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.BStory,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.BStory
            },
        };
    }

}