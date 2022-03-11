using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class BreakIntoThree : ISequence
{
    public string Name { get { return "Break Into Three"; } }
    public string EventsDescription { get { return "The Hero's recent Ego Death is synthesized with a final injection of hidden information to reveal the key to defeat the Problem. But a new twist threatens all! The Hero plans one last desperate attempt to defeat the Problem."; } }
    public string ContextDescription { get { return "The Hero answers the Dramatic Question with lessons learned from the characters in the subplot, demonstrating they have what it takes to overcome their flaws."; } }

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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.BreakIntoThree)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.BreakIntoThree,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.BreakIntoThree,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.BreakIntoThree
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.BreakIntoThree)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.BreakIntoThree,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.BreakIntoThree,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.BreakIntoThree
            },
        };
    }

}