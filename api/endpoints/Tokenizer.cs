using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StoryGhost.Interfaces;
using StoryGhost.Models;
using System.Security.Claims;

namespace StoryGhost.Generate;

public class Tokenizer
{
    private readonly IEncodingService _encodingService;

    public Tokenizer(IEncodingService encodingService)
    {
        _encodingService = encodingService;
    }

    [FunctionName("Encode")]
    public async Task<IActionResult> Encode([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Tokenizer/Encode")] EncodeRequest body, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var result = await _encodingService.Encode(body.Text);

        return new OkObjectResult(result);
    }
}