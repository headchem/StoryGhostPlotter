using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Debate : ISequence
{
    public string Name { get { return "Debate"; } }
    public string EventsDescription { get { return "Having realized stasis=death in the Setup, they are now explicitly confronted with what's at stake for them to lose."; } }
    public string ContextDescription { get { return "The Hero is in shock and doubts if they have what it takes to tackle the Problem."; } }

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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.Debate)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.Debate,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.Debate,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.Debate
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.Debate)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.Debate,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.Debate,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.Debate
            },
        };
    }

}