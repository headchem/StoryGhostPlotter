using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Climax : ISequence
{
    public string Name { get { return "Climax"; } }
    public string Description { get { return "In a final showdown, the Hero overcomes their weaknesses and shadow side, as they enact their ingenious plan. The Hero incorporates the answer to the Dramatic Question into their fight against the Problem."; } }

    public string GetLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"{Name} advice goes here... {Description}";
    }

    public AdviceComponents GetAdvice(string genre, string problemTemplate, string heroArchetype, string enemyArchetype, string primalStakes, string dramaticQuestion)
    {
        var genreObj = Factory.GetGenre(genre);
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var enemyArchetypeObj = Factory.GetArchetype(enemyArchetype);
        var primalStakesObj = Factory.GetPrimalStake(primalStakes);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new AdviceComponents
        {
            Common = Description,
            Genre = genreObj.AdviceSequence.Climax,
            ProblemTemplate = problemTemplateObj.AdviceSequence.Climax,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.Climax,
            EnemyArchetype = enemyArchetypeObj.EnemyAdviceSequence.Climax,
            PrimalStakes = primalStakesObj.AdviceSequence.Climax,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.Climax
        };
    }

}