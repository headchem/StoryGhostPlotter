using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class DarkNightOfTheSoul : ISequence
{
    public string Name { get { return "Dark Night Of The Soul"; } }
    public string Description { get { return "The Hero wallows in hopelessness and mourns what has \"died\". The death of something old makes way for something new to be born, but the fertile ground remains unseeded for now."; } }

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
            Genre = genreObj.AdviceSequence.DarkNightOfTheSoul,
            ProblemTemplate = problemTemplateObj.AdviceSequence.DarkNightOfTheSoul,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.DarkNightOfTheSoul,
            EnemyArchetype = enemyArchetypeObj.EnemyAdviceSequence.DarkNightOfTheSoul,
            PrimalStakes = primalStakesObj.AdviceSequence.DarkNightOfTheSoul,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.DarkNightOfTheSoul
        };
    }

}