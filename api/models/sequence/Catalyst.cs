using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Catalyst : ISequence
{
    public string Name { get { return "Catalyst"; } }
    public string Description { get { return "Introduce the Problem through an Inciting Incident that irreversibly shatters the Hero's status quo. The Hero isn't sure what to make of it, but it is ultimately what they need to grow."; } }

    public AdviceComponents GetAdvice(string genre, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genreObj = Factory.GetGenre(genre);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genre = genreObj.AdviceSequence.IncitingIncident,
            ProblemTemplate = problemTemplateObj.AdviceSequence.IncitingIncident,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.IncitingIncident,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.IncitingIncident
        };
    }

}