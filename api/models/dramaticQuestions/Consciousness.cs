using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Consciousness : IDramaticQuestion
{
    public string Id { get { return "consciousness"; } }
    public string Name { get { return "Consciousness"; } }
    public string Description { get { return "Is the risk of eternal damnation worth existing in the first place?"; } }
    public string Contrary { get { return "Unconsciousness"; } }
    public string Contradiction { get { return "Death"; } }
    public string Negation { get { return "Damnation"; } }
    public string Positive { get { return "Consciousness"; } }

    public string GetLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return "Consciousness LogLine promp contribution...";
    }

}