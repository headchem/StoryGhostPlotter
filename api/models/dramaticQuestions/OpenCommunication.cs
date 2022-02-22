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

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                ThemeStated = $"Subtly pose the dramatic question of \"{Description}\". The Hero doesn't have the experience or context yet to understand this theme of {Name.ToLower()}.",
                Debate = $"The main character shows {Contrary.ToLower()}.",
                FunAndGames = $"The main character shows {Contradiction.ToLower()}.",
                DarkNightOfTheSoul = $"The main character shows {Negation.ToLower()}.",
                Climax = $"The main character shows {Positive.ToLower()}."
            };
        }
    }

    public string GetLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate)
    {
        return $"The overarching theme of this story is asking if babbling nonsense can ultimately communicate an important idea.";
    }

}