using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Midpoint : ISequence
{
    public string Name { get { return "Midpoint"; } }
    public string Description { get { return "Hidden info about the Problem or a character is revealed, recontextualizing the situation, further raising the stakes for the Hero. The Hero, or their perfectly in sync team, wins a victory, but it's a false victory because the Hero still lacks personal growth."; } }

    public AdviceComponents GetAdvice(string genre, string problemTemplate, string heroArchetype, string dramaticQuestion)
    {
        var genreObj = Factory.GetGenre(genre);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genre = genreObj.AdviceSequence.Midpoint,
            ProblemTemplate = problemTemplateObj.AdviceSequence.Midpoint,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Midpoint,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.Midpoint
        };
    }

}