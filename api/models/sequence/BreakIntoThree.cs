using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class BreakIntoThree : ISequence
{
    public string Name { get { return "Break Into Three"; } }
    public string Description { get { return "The Hero answers the Dramatic Question with lessons learned from the characters in the subplot. The Hero's recent Ego Death is synthesized with a final injection of hidden information to reveal the key to defeat the Problem. But a new twist threatens all! The Hero plans one last desperate attempt to defeat the Problem."; } }
    
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

        return $"{Description} {problemTemplateObj.BreakIntoThree} {heroArchetypeObj.BreakIntoThree}";
    }

}