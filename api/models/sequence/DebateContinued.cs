using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class DebateContinued : ISequence
{
    public string Name { get { return "Debate (Continued)"; } }
    public string Description { get { return "The Hero and supporting characters continue debating whether they can tackle the problem."; } }

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
            Genre = genreObj.AdviceSequence.DebateContinued,
            ProblemTemplate = problemTemplateObj.AdviceSequence.DebateContinued,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.DebateContinued,
            EnemyArchetype = enemyArchetypeObj.EnemyAdviceSequence.DebateContinued,
            PrimalStakes = primalStakesObj.AdviceSequence.DebateContinued,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.DebateContinued
        };
    }

}