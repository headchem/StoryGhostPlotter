using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class AllHopeIsLost : ISequence
{
    public string Name { get { return "All Hope Is Lost"; } }
    public string Description { get { return "The Hero suffers a crushing defeat, and victory over the Problem now appears impossible. All progress has been lost, and anything good left has no meaning. Something (perhaps emotional) or someone dies."; } }
    
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

        return new AdviceComponents{
            Common = Description,
            Genre = genreObj.AdviceSequence.AllHopeIsLost,
            ProblemTemplate = problemTemplateObj.AdviceSequence.AllHopeIsLost,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.AllHopeIsLost,
            EnemyArchetype = enemyArchetypeObj.EnemyAdviceSequence.AllHopeIsLost,
            PrimalStakes = primalStakesObj.AdviceSequence.AllHopeIsLost,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.AllHopeIsLost
        };
    }

}