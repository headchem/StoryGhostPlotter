using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class SetupContinued : ISequence
{
    public string Name { get { return "Setup (Continued)"; } }
    public string EventsDescription { get { return "Continue introducing the characters and setting."; } }
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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.SetupContinued)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.SetupContinued,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.SetupContinued,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.SetupContinued
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.SetupContinued)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.SetupContinued,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.SetupContinued,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.SetupContinued
            },
        };
    }

}