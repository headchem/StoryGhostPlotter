using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Cooldown : ISequence
{
    public string Name { get { return "Cooldown"; } }
    public string Description { get { return "A bookend to the Opening Image, the Hero demonstrates how they have grown as a person, as they reflect with their team on the ordeal they have survived."; } }

    public AdviceComponents GetAdvice(string genre, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genreObj = Factory.GetGenre(genre);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genre = genreObj.AdviceSequence.Cooldown,
            ProblemTemplate = problemTemplateObj.AdviceSequence.Cooldown,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Cooldown,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.Cooldown
        };
    }

}