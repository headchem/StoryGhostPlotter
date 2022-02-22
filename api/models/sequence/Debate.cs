using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Debate : ISequence
{
    public string Name { get { return "Debate"; } }
    public string Description { get { return "The Hero is in shock and doubts if they have what it takes to tackle the Problem. Having realized stasis=death in the Setup, they are now explicitly confronted with what's at stake for them to lose."; } }

    public AdviceComponents GetAdvice(string genre, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genreObj = Factory.GetGenre(genre);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genre = genreObj.AdviceSequence.Debate,
            ProblemTemplate = problemTemplateObj.AdviceSequence.Debate,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Debate,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.Debate
        };
    }

}