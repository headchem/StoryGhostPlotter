using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class BadGuysCloseIn : ISequence
{
    public string Name { get { return "Bad Guys Close In"; } }
    public string EventsDescription { get { return "In-fighting, doubt and jealousy tear the Hero's team apart. The Enemy or problem is temporarily defeated or alleviated, but it is simmering and regrouping to wreak even greater havoc on the Hero in the future."; } }
    public string ContextDescription { get { return "The subplot interweaves with the main plot, building tension without resolution. How does the Enemy/Problem currently feel about the Hero?"; } }

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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.BadGuysCloseIn)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.BadGuysCloseIn,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.BadGuysCloseIn,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.BadGuysCloseIn
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.BadGuysCloseIn)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.BadGuysCloseIn,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.BadGuysCloseIn,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.BadGuysCloseIn
            },
        };
    }

}