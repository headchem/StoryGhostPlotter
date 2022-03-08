using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class ThemeStated : ISequence
{
    public string Name { get { return "Theme Stated"; } }
    public string EventsDescription { get { return ""; } } // this is covered by the Dramatic Question description
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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.ThemeStated)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.ThemeStated,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.ThemeStated,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.ThemeStated
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.ThemeStated)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.ThemeStated,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.ThemeStated,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.ThemeStated
            },
        };
    }

}