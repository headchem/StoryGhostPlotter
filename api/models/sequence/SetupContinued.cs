using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class SetupContinued : ISequence
{
    public string Name { get { return "Setup (Continued)"; } }
    public string Description { get { return "Continue introducing the characters and setting."; } }

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
            Genre = genreObj.AdviceSequence.SetupContinued,
            ProblemTemplate = problemTemplateObj.AdviceSequence.SetupContinued,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.SetupContinued,
            EnemyArchetype = enemyArchetypeObj.EnemyAdviceSequence.SetupContinued,
            PrimalStakes = primalStakesObj.AdviceSequence.SetupContinued,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.SetupContinued
        };
    }

}