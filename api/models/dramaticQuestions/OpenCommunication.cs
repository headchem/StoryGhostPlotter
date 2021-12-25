using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class OpenCommunication : IDramaticQuestion
{
    public string Id { get { return "openCommunication"; } }
    public string Name { get { return "Open Communication"; } }
    public string Description { get { return "Can babbling nonsense clearly communicate an important idea?"; } }

    public string Contrary { get { return "Alienation"; } }
    public string Contradiction { get { return "Isolation"; } }
    public string Negation { get { return "Insantiy"; } }
    public string Positive { get { return "Open Communication"; } }

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The theme of the story is {Name}, which asks the dramatic question of \"{Description}\"";
    }

}