using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoryGhost.Models;
using StoryGhost.Models.Completions;

namespace StoryGhost.Interfaces;

public interface IPlotService
{
    public Task<Plot> CreateNewPlot(string userId, string userDisplayName, string newPlotName);

    public Task<Plot> GetPlot(string userId, string plotId);

    public Task SavePlot(string userId, string plotId, Plot curPlotObj, Plot plot);

    public Task DeletePlot(string userId, string plotId);
}