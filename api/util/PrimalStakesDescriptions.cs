using System;
using StoryGhost.Models;

namespace StoryGhost.Util;
public static class PrimalStakesDescriptions
{
    public static PrimalStakes GetPrimalStakesDescription(string primalStakes) {
        return new PrimalStakes{
            Name = primalStakes,
            Description = $"Desc for primal stakes: {primalStakes}"
        };
    }
}
