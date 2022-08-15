using System;
using System.Collections.Generic;
using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface IEmotion
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
}