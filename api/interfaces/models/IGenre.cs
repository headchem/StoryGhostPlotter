using System;
using System.Collections.Generic;
using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface IGenre
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public List<string> Keywords { get; }

    public AdviceSequence AdviceSequence { get; }

    public string GetLogLineContribution(long seed, IProblemTemplate problemTemplate, IDramaticQuestion dramaticQuestion);
}