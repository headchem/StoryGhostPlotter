using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class Climax : ISequence
{
    public string Name { get { return "Climax"; } }
    public string Description { get { return "In a final showdown, the Hero overcomes their weaknesses and shadow side, as they enact their ingenious plan. The Hero incorporates the answer to the Dramatic Question into their fight against the Problem."; } }
    
    public string GetLogLineContribution(int seed, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"{Name} advice goes here... {Description}";
    }

    public string GetAdvice(string problemTemplate, string heroArchetype, string enemyArchetype, string primalStakes, string dramaticQuestion)
    {
        var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);
        var heroArchetypeObj = Factory.GetArchetype(heroArchetype);
        var enemyArchetypeObj = Factory.GetArchetype(enemyArchetype);
        var primalStakesObj = Factory.GetPrimalStake(primalStakes);
        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return $"{Description} {problemTemplateObj.Climax} {heroArchetypeObj.Climax}";
    }

}