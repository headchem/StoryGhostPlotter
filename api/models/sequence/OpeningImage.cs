using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class OpeningImage : ISequence
{
    public string Name { get { return "Opening Image"; } }
    public string EventsDescription { get { return "Present a brief snapshot of the world the Hero lives in, or the Hero's status quo life, and what they are missing. Establish the tone of the story, and hint at the problem to come."; } }
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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.OpeningImage)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.OpeningImage,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.OpeningImage,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.OpeningImage
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.OpeningImage)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.OpeningImage,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.OpeningImage,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.OpeningImage
            },
        };
    }

}