using System;
using System.Collections.Generic;
using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface ISequence
{
    public string Name { get; }
    public string Description { get; }

    public AdviceComponents GetAdvice(string genre, string problemTemplate, string heroArchetype, string dramaticQuestion);
}