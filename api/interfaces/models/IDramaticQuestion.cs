using System;
using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface IDramaticQuestion
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }

    /// <summary>Occurs first. Better than the <c>Contradiction</c>, but still not <c>Positive</c>.</summary>
    public string Contrary { get; }

    /// <summary>Occurs second. Opposite of the <c>Positive</c>.</summary>
    public string Contradiction { get; }

    /// <summary>Occurs thrid. Darkest depths, extreme perversion of the <c>Positive</c>.</summary>
    public string Negation { get; }

    /// <summary>Occurs fourth. Primary value at stake.</summary>
    public string Positive { get; }

    public AdviceSequence AdviceSequence { get; }

    public string GetLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes);
}