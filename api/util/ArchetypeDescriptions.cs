using System;
using StoryGhost.Models;

namespace StoryGhost.Util;
public static class ArchetypeDescriptions
{
    public static Archetype GetArchetypeDescription(string archetype) {
        return new Archetype{
            Name = archetype,
            Description = $"Desc for archetype: {archetype}"
        };
    }
}
