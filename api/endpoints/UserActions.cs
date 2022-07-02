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
        try
        {
            var user = StaticWebAppsAuth.Parse(req);
            if (user.Identity == null || !user.Identity.IsAuthenticated) return new UnauthorizedResult();

            var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            var displayName = user.Identity.Name;

            var userObj = await _userService.GetOrCreateUser(userId, displayName);

            return new OkObjectResult(userObj);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            throw ex;
        }
    }

    [FunctionName("NewPlot")]
    public async Task<IActionResult> NewPlot([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "NewPlot")] string NewPlotName, HttpRequest req, ILogger log)
    {
        try
        {
            var user = StaticWebAppsAuth.Parse(req);
            if (user.Identity == null || !user.Identity.IsAuthenticated) return new UnauthorizedResult();
            var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (string.IsNullOrWhiteSpace(NewPlotName))
            {
                NewPlotName = "New Plot - " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            }

            var newPlot = await _plotService.CreateNewPlot(userId, user.Identity.Name, NewPlotName);

            return new OkObjectResult(newPlot.Id);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            throw ex;
        }
    }

    [FunctionName("GetPlot")]
    public async Task<IActionResult> GetPlot([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetPlot")] HttpRequest req, ILogger log)
    {
        try
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
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            throw ex;
        }
    }

    [FunctionName("SaveLogLine")]
    public async Task<IActionResult> SaveLogLine([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "SaveLogLine")] Plot plot, HttpRequest req, ILogger log)
    {
        try
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
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            throw ex;
        }
    }

    [FunctionName("DeletePlot")]
    public async Task<IActionResult> DeletePlot([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "DeletePlot")] HttpRequest req, ILogger log)
    {
        try
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
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            throw ex;
        }
    }


    [FunctionName("AddTokens")] // NOTE: "Admin" is a reserved route by Azure Functions, so we call ours something different (SGAdmin)
    public async Task<IActionResult> CreateLogLineFinetuningDataset([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "SGAdmin/AddTokens")] HttpRequest req, ILogger log)
    {
        try
        {
            var user = StaticWebAppsAuth.Parse(req);
            if (!user.IsInRole("admin")) return new UnauthorizedResult();

            var targetUserId = req.Query["targetUserId"][0];
            var tokensToAdd = int.Parse(req.Query["tokensToAdd"][0]);

            await _userService.AddTokens(targetUserId, tokensToAdd);

            return new OkObjectResult($"{tokensToAdd} tokens added to userId: {targetUserId}");
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            throw ex;
        }
    }


    [FunctionName("GetTokensRemaining")]
    public async Task<IActionResult> GetTokensRemaining([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetTokensRemaining")] HttpRequest req, ILogger log)
    {
        try
        {
            var user = StaticWebAppsAuth.Parse(req);
            if (user.Identity == null || !user.Identity.IsAuthenticated) return new UnauthorizedResult();
            var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

            var tokensRemaining = await _userService.GetTokensRemaining(userId);

            return new OkObjectResult(tokensRemaining);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            throw ex;
        }
    }

}