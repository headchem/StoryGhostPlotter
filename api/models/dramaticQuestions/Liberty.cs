using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Liberty : IDramaticQuestion
{
    public string Id { get { return "liberty"; } }
    public string Name { get { return "Liberty"; } }
    public string Description { get { return "Can freedom be found in slavery?"; } }

    public string Contrary { get { return "Restraint"; } }
    public string Contradiction { get { return "Slavery"; } }
    public string Negation { get { return "Slavery perceived as freedom"; } }
    public string Positive { get { return "Liberty"; } }

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The theme of the story is {Name}, which asks the dramatic question of \"{Description}\"";
    }

}