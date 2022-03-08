using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class DarkNightOfTheSoul : ISequence
{
    public string Name { get { return "Dark Night Of The Soul"; } }
    public string EventsDescription { get { return "The Hero wallows in hopelessness and mourns what has \"died\". The death of something old makes way for something new to be born, but the fertile ground remains unseeded for now."; } }
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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.DarkNightOfTheSoul)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.DarkNightOfTheSoul,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.DarkNightOfTheSoul,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.DarkNightOfTheSoul
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.DarkNightOfTheSoul)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.DarkNightOfTheSoul,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.DarkNightOfTheSoul,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.DarkNightOfTheSoul
            },
        };
    }

}