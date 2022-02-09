using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Util;

namespace StoryGhost.Models.Sequences;

public class FunAndGames : ISequence
{
    public string Name { get { return "Fun And Games"; } }
    public string Description { get { return "The Hero proactively attempts to resolve the problem while exploring this new upside-down world. Focus on the subplot (typically the love interest) and heavily infuse the Dramatic Question into the dialogue and events. The Hero meets new characters who are the antithesis of everything they knew in their old status quo life. This is the fun part of the story."; } }
    
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

        return $"{Description} {problemTemplateObj.FunAndGames} {heroArchetypeObj.FunAndGames}";
    }

}