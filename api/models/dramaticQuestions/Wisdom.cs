using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Wisdom : IDramaticQuestion
{
    public string Id { get { return "wisdom"; } }
    public string Name { get { return "Wisdom"; } }
    public string Description { get { return "Can faking intelligence lead to true wisdom?"; } }

    public string Contrary { get { return "Ignorance"; } }
    public string Contradiction { get { return "Stupidity"; } }
    public string Negation { get { return "Stupidity perceived as intelligence"; } }
    public string Positive { get { return "Wisdom"; } }

    public string GetLogLineContribution(int seed, string CompletionType, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The overarching theme of this story is asking if faking intelligence can lead to true wisdom.";
    }

}