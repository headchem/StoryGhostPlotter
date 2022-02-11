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

    [FunctionName("GetPlot")]
    public static IActionResult GetPlot([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetPlot")] HttpRequest req, ILogger log)
    {
        var id = req.Query["id"];

        // get Plot from Cosmos
        // check if current user is same as Plot author
        // should be same Ids as in LogLineOptions

        var plot = new Plot();

        if (id == "123") {
            plot.Genre = "fantasy";
            plot.ProblemTemplate = "outOfTheBottle";
            plot.Keywords = new List<string>{"genie", "wish", "lamp"};
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
        } else if (id == "444") {

        }

        return new OkObjectResult(plot);
    }
}
