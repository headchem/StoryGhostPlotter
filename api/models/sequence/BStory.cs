using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class BStory : ISequence
{
    public string Name { get { return "B Story"; } }
    public string EventsDescription { get { return ""; } }
    public string ContextDescription { get { return "While the main story is the hero's tangible goal, the B-Story is the hero's spiritual goal. It usually takes the form of a love story, or a mentorship, set against the backdrop of the main action. The B-Story hammers home the theme that the hero needs to learn, and often focuses on how a side character nurtures and enables the Hero."; } }

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