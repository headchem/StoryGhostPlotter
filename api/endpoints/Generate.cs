using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StoryGhost.Models;
using StoryGhost.Util;
using StoryGhost.LogLine;
using Polly;

using StoryGhost.Interfaces;

namespace StoryGhost.Generate;

public class Generate
{
    private readonly ICompletionService _completionService;

    public Generate(ICompletionService completionService) {
        _completionService = completionService;
    }

    [FunctionName("Generate")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] Story story, ILogger log)
    {
        var result = await _completionService.GetCompletion(story);

        return new OkObjectResult(result);
    }
}
