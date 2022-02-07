using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Newtonsoft.Json;
using StoryGhost.Util;
using StoryGhost.Models;

namespace StoryGhost.LogLine;
public static class UserActions
{
    [FunctionName("User")]
    public static IActionResult GetUser([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "User")] HttpRequest req, ILogger log)
    {
        var user = new User{
            PlotReferences = new List<PlotReference>{
                new PlotReference{
                    PlotId = "123",
                    DisplayName = "My first story"
                },
                new PlotReference{
                    PlotId = "444",
                    DisplayName = "My second story"
                },
            }
        };

        return new OkObjectResult(user);
    }

    [FunctionName("NewPlot")]
    public static IActionResult NewPlot([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "NewPlot")] string NewPlotName, HttpRequest req, ILogger log)
    {
        // create new plot in cosmos, return Id

        var newPlotId = "999";

        return new OkObjectResult(newPlotId);
    }
}
