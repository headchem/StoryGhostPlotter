using System;
using System.Collections.Generic;
using System.Linq;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class AllHopeIsLost : ISequence
{
    public string Name { get { return "All Hope Is Lost"; } }
    public string EventsDescription { get { return "The Hero suffers a crushing defeat, and victory over the Problem now appears impossible. All progress has been lost, and anything good left has no meaning. Something (perhaps emotional or symbolic) or someone dies."; } }
    public string ContextDescription { get { return "The Hero is ready to give up."; } }

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
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Events.AllHopeIsLost)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Events.AllHopeIsLost,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Events.AllHopeIsLost,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Events.AllHopeIsLost
            },
            Context = new AdviceComponents
            {
                Common = ContextDescription,
                Genres = string.Join(" ", genresList.Select(g => g.AdviceSequence.Context.AllHopeIsLost)),
                ProblemTemplate = problemTemplateObj.AdviceSequence.Context.AllHopeIsLost,
                HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Context.AllHopeIsLost,
                DramaticQuestion = dramaticQuestionObj.AdviceSequence.Context.AllHopeIsLost
            },
        };

    }

}