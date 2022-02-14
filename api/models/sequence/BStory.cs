using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class BStory : ISequence
{
    public string Name { get { return "B Story"; } }
    public string Description { get { return "The B Story is usually the love story set against the backdrop of the main action."; } }

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
            Genre = genreObj.AdviceSequence.BStory,
            ProblemTemplate = problemTemplateObj.AdviceSequence.BStory,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.BStory,
            EnemyArchetype = enemyArchetypeObj.EnemyAdviceSequence.BStory,
            PrimalStakes = primalStakesObj.AdviceSequence.BStory,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.BStory
        };
    }

}