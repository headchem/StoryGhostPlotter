using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Climax : ISequence
{
    public string Name { get { return "Climax"; } }
    public string EventsDescription { get { return "In a final showdown, the Hero overcomes their weaknesses and shadow side, as they enact their ingenious plan. The Hero incorporates the answer to the Dramatic Question into their fight against the Problem."; } }
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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.Climax)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.Climax,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.Climax,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.Climax
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.Climax)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.Climax,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.Climax,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.Climax
            },
        };
    }

}