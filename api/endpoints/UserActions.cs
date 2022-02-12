using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using StoryGhost.Util;
using StoryGhost.Models;



namespace StoryGhost.LogLine;
public class UserActions
{
    private readonly CosmosClient _db;

    public UserActions(CosmosClient db)
    {
        _db = db;
    }

    [FunctionName("User")]
    public async Task<IActionResult> GetUser([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "User")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (user.Identity == null || !user.Identity.IsAuthenticated) return new UnauthorizedResult();

        //if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        using (log.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = user.Identity.Name }))
        {
            //log.LogInformation("An example of an Information level message");

            // Read the item to see if it exists.
            var container = _db.GetContainer(databaseId: "Plotter", containerId: "Users");

            try
            {
                var userResponse = await container.ReadItemAsync<StoryGhost.Models.User>(userId, new PartitionKey(userId)); //await _db.ReadItemAsync<TestUser>(u.Id, new PartitionKey(u.UserId));
                var RUs = userResponse.RequestCharge;
                var existingUserObj = userResponse.Resource;

                return new OkObjectResult(existingUserObj);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                var newUser = new StoryGhost.Models.User
                {
                    Id = userId,
                    DisplayName = user.Identity.Name
                };

                try
                {
                    var newUserResponse = await container.CreateItemAsync<StoryGhost.Models.User>(newUser, new PartitionKey(newUser.Id));
                    var RUs = newUserResponse.RequestCharge;
                    var newUserObj = newUserResponse.Resource;

                    return new OkObjectResult(newUserObj);
                }
                catch (Exception exNewUser)
                {
                    log.LogError($"Failed to create new user: {user.Identity.Name}, userId: {userId}");
                }
            }
        }

        throw new Exception("Unable to retrieve user");
    }

    [FunctionName("NewPlot")]
    public IActionResult NewPlot([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "NewPlot")] string NewPlotName, HttpRequest req, ILogger log)
    {
        // create new plot in cosmos, return Id

        var newPlotId = "999";

        return new OkObjectResult(newPlotId);
    }

    [FunctionName("GetPlot")]
    public IActionResult GetPlot([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetPlot")] HttpRequest req, ILogger log)
    {
        var id = req.Query["id"];

        // get Plot from Cosmos
        // check if current user is same as Plot author
        // should be same Ids as in LogLineOptions

        var plot = new Plot();

        if (id == "123")
        {
            plot.Title = "Aladin";
            plot.Genre = "fantasy";
            plot.ProblemTemplate = "outOfTheBottle";
            plot.Keywords = new List<string> { "genie", "wish", "lamp" };
            plot.HeroArchetype = "orphan";
            plot.EnemyArchetype = "magician";
            plot.PrimalStakes = "findConnection";
            plot.DramaticQuestion = "truth";

            plot.Sequences = new List<UserSequence>{
                new UserSequence{
                    SequenceName = "Opening Image",
                    Text = "The sands of the Middle East lead to a peddler on the outskirts of Agrabah.",
                    IsLocked = true,
                    isReadOnly = true,
                    Allowed = new List<string>{"Opening Image"}
                },
                new UserSequence{
                    SequenceName = "Setup",
                    Text = "Jafar, the Sultan's adviser, finds the Cave of Wonders. The magic cave tells Jafar only a Diamond in the Rough may enter. In Agrabah, street urchin Aladdin avoids the Sultan's guards as he steals food to eat. Aladdin and his monkey Abu see some starving children and give them their bread rather than let them go hungry.",
                    IsLocked = true,
                    isReadOnly = false,
                    Allowed = new List<string>{"Setup", "Theme Stated"}
                },
                new UserSequence{
                    SequenceName = "Theme Stated",
                    Text = "Aladdin laments the fact that everyone looks down on him as a mere \"street rat,\" admonishing that if they looked closer, they'd see that there is so much more to him.",
                    IsLocked = false,
                    isReadOnly = false,
                    Allowed = new List<string>{"Theme Stated", "Catalyst"}
                },
            };
        }
        else if (id == "444")
        {

        }

        return new OkObjectResult(plot);
    }

    [FunctionName("SaveLogLine")]
    public IActionResult SaveLogLine([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "SaveLogLine")] Plot plot, HttpRequest req, ILogger log)
    {
        var id = req.Query["id"];

        var title = plot.Title;

        // update existing plot

        return new NoContentResult();
    }

    [FunctionName("SaveSequenceText")]
    public IActionResult SaveSequenceText([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "SaveSequenceText")] UserSequence sequence, HttpRequest req, ILogger log)
    {
        var id = req.Query["id"];

        var text = sequence.Text;

        // update existing plot

        return new NoContentResult();
    }
}
