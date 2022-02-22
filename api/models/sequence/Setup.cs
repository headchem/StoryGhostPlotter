using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Setup : ISequence
{
    public string Name { get { return "Setup"; } }
    public string Description { get { return "Introduce the Hero in more detail. Establish what they value - what's at stake for them to lose? Foreshadow the rest of story. End with the Hero realizing they can't keep living this way, but they're not sure what else to do."; } }

    public AdviceComponents GetAdvice(string genre, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genreObj = Factory.GetGenre(genre);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genre = genreObj.AdviceSequence.Setup,
            ProblemTemplate = problemTemplateObj.AdviceSequence.Setup,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Setup,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.Setup
        };
    }

}