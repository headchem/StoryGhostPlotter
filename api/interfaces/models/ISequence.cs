using System;
using System.Collections.Generic;
using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface ISequence
{
    public string Name { get; }
    public string EventsDescription { get; }
    public string ContextDescription { get; }

    public AdviceComponentsWrapper GetAdvice(List<string> genres, string problemTemplate, string heroArchetype, string dramaticQuestion);
}