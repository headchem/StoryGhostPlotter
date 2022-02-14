using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Catalyst : ISequence
{
    public string Name { get { return "Catalyst"; } }
    public string Description { get { return "Introduce the Problem through an Inciting Incident that irreversibly shatters the Hero's status quo. The Hero considers it an intensely negative event, but it's secretly what they need to grow."; } }

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
            Genre = genreObj.AdviceSequence.IncitingIncident,
            ProblemTemplate = problemTemplateObj.AdviceSequence.IncitingIncident,
            HeroArchetype = heroArchetypeObj.HeroAdviceSequence.IncitingIncident,
            EnemyArchetype = enemyArchetypeObj.EnemyAdviceSequence.IncitingIncident,
            PrimalStakes = primalStakesObj.AdviceSequence.IncitingIncident,
            DramaticQuestion = dramaticQuestionObj.AdviceSequence.IncitingIncident
        };
    }

}