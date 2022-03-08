using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class FunAndGames : ISequence
{
    public string Name { get { return "Fun And Games"; } }
    public string EventsDescription { get { return "The Hero proactively attempts to resolve the problem while exploring this new upside-down world. Focus on the B Story subplot (typically the love interest) and heavily infuse the Dramatic Question into the dialogue and events. The Hero meets new characters who are the antithesis of everything they knew in their old status quo life. This is the fun part of the story."; } }
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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.FunAndGames)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.FunAndGames,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.FunAndGames,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.FunAndGames
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.FunAndGames)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.FunAndGames,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.FunAndGames,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.FunAndGames
            },
        };
    }

}