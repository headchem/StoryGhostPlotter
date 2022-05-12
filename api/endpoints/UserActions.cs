using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

using StoryGhost.Models;

using StoryGhost.Interfaces;

namespace StoryGhost.LogLine;
public class UserActions
{
    private readonly IUserService _userService;
    private readonly IPlotService _plotService;

    public UserActions(IUserService userService, IPlotService plotService)
    {
        _userService = userService;
        _plotService = plotService;
    }

    /// <summary>
    /// Ensure current user is logged in, then check if a Cosmos container exists for them. If a container exists, return it, otherwise create a new container.
    /// </summary>
    [FunctionName("User")]
    public async Task<IActionResult> GetUser([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "User")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (user.Identity == null || !user.Identity.IsAuthenticated) return new UnauthorizedResult();

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
        var displayName = user.Identity.Name;

        var userObj = await _userService.GetOrCreateUser(userId, displayName);

        return new OkObjectResult(userObj);
    }

    [FunctionName("NewPlot")]
    public async Task<IActionResult> NewPlot([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "NewPlot")] string NewPlotName, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (user.Identity == null || !user.Identity.IsAuthenticated) return new UnauthorizedResult();
        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var newPlot = await _plotService.CreateNewPlot(userId, user.Identity.Name, NewPlotName);

        return new OkObjectResult(newPlot.Id);
    }

    [FunctionName("GetPlot")]
    public async Task<IActionResult> GetPlot([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetPlot")] HttpRequest req, ILogger log)
    {
        var plotId = req.Query["id"][0];
        var authorId = "";
        var curUser = StaticWebAppsAuth.Parse(req);

        // if "a" is in the url, use that as the authorId (partition key) otherwise use the currently authenticated userId
        if (req.Query.ContainsKey("a"))
        {
            authorId = req.Query["a"][0];
        }
        else if (curUser.Identity != null && curUser.Identity.IsAuthenticated)
        {
            authorId = curUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        var plotObj = await _plotService.GetPlot(authorId, plotId);

        if (plotObj.IsDeleted) return new NotFoundResult();

        if (plotObj.IsPublic)
        {
            return new OkObjectResult(plotObj);
        }

        if (curUser.Identity == null || !curUser.Identity.IsAuthenticated) return new UnauthorizedResult();
        var curUserId = curUser.FindFirst(ClaimTypes.NameIdentifier).Value;

        // to reach this point, plot must NOT be public, so only return object is author == current user
        if (plotObj.UserId != curUserId) return new UnauthorizedResult();

        return new OkObjectResult(plotObj);
    }

    [FunctionName("SaveLogLine")]
    public async Task<IActionResult> SaveLogLine([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "SaveLogLine")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (user.Identity == null || !user.Identity.IsAuthenticated) return new UnauthorizedResult();
        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var plotId = req.Query["id"][0];

        var curPlotObj = await _plotService.GetPlot(userId, plotId);

        if (curPlotObj.UserId != userId) return new UnauthorizedResult();

        await _plotService.SavePlot(userId, plotId, curPlotObj, plot);

        return new NoContentResult();
    }

    [FunctionName("DeletePlot")]
    public async Task<IActionResult> DeletePlot([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "DeletePlot")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (user.Identity == null || !user.Identity.IsAuthenticated) return new UnauthorizedResult();
        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var plotId = req.Query["id"][0];

        var curPlotObj = await _plotService.GetPlot(userId, plotId);

        if (curPlotObj.IsDeleted) return new NotFoundResult();

        if (curPlotObj.UserId != userId) return new UnauthorizedResult();

        // update IsDeleted to true in both the Plot item and the User.PlotReferences item

        await _userService.DeletePlotReference(userId, plotId);
        await _plotService.DeletePlot(userId, plotId);

        return new NoContentResult();
    }

}