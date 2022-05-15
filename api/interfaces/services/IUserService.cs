using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoryGhost.Models;
using StoryGhost.Models.Completions;

namespace StoryGhost.Interfaces;

public interface IUserService
{
    ///<summary></summary>
    public Task<StoryGhost.Models.User> GetOrCreateUser(string userId, string displayName);

    public Task CreatePlotReference(string userId, Plot newPlot);

    public Task DeletePlotReference(string userId, string plotId);

    public Task<int> GetTokensRemaining(string userId);

    public Task AddTokens(string userId, int numTokens);

    public Task DeductTokens(string userId, int numTokens);
}