using System;
using StoryGhost.Models;

namespace StoryGhost.Util;
public static class GenreDescriptions
{
    public static Genre GetGenreDescription(string genre) {
        return new Genre{
            Name = genre,
            Description = $"Desc for genre: {genre}"
        };
    }
}
