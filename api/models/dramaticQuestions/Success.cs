using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Success : IDramaticQuestion
{
    public string Id { get { return "success"; } }
    public string Name { get { return "Success"; } }
    public string Description { get { return "Is selling out truly a form of success?"; } }

    public string Contrary { get { return "Compromise"; } }
    public string Contradiction { get { return "Failure"; } }
    public string Negation { get { return "Selling Out"; } }
    public string Positive { get { return "Success"; } }

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The theme of the story is {Name}, which asks the dramatic question of \"{Description}\"";
    }

}