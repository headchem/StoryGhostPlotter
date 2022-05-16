using System;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

using StoryGhost.Interfaces;
using StoryGhost.Models;
using StoryGhost.Models.Completions;
using StoryGhost.Util;
using StoryGhost.LogLine;
using Microsoft.ApplicationInsights;

namespace StoryGhost.Services;

public class AnalysisService : IAnalysisService
{
    private readonly HttpClient _httpClient;
    private readonly IUserService _userService;
    private readonly IPlotService _plotService;
    private readonly ILogger<AnalysisService> _logger;
    private TelemetryClient _telemetry;

    public AnalysisService(ILogger<AnalysisService> logger, TelemetryClient telemetry, HttpClient httpClient, IUserService userService, IPlotService plotService)
    {
        _logger = logger;
        _telemetry = telemetry;
        _httpClient = httpClient;
        _userService = userService;
        _plotService = plotService;
    }

    public async Task<bool> IsToxic(string userId, string text)
    {
        var prompt = $"<|endoftext|>{text}\n--\nLabel:";

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            MaxTokens = 1,
            Temperature = 0.0,
            TopP = 0.0,
            Logprobs = 5,
            LogitBias = new Dictionary<string, int>(),
            UserId = userId,
        };

        var jsonString = JsonSerializer.Serialize(openAIRequest);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var engineURL = "engines/content-filter-alpha/completions";

        var response = await _httpClient.PostAsync(engineURL, content);

        if (response.IsSuccessStatusCode == false)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception(errorResponse);
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var resultDeserialized = JsonSerializer.Deserialize<OpenAICompletionsResponse>(apiResponse);

        var completionObj = resultDeserialized.Choices.FirstOrDefault();

        if (completionObj == null) {
            _logger.LogError("IsToxic call resulted in empty response. Presumed OpenAI failure, defaulting to IsToxic=false to avoid user impact.");
            return false;
        }

        // output_label values:
        // 0 - The text is safe.
        // 1 - This text is sensitive. This means that the text could be talking about a sensitive topic, something political, religious, or talking about a protected class such as race or nationality.
        // 2 - This text is unsafe. This means that the text contains profane language, prejudiced or hateful language, something that could be NSFW, or text that portrays certain groups/people in a harmful manner.

        var output_label  = completionObj.Text.Trim();
        var logprobs = completionObj.LogProbs.TopLogProbs[0];

        // below logic converted from python script here: https://beta.openai.com/docs/engines/content-filter
        // This is the probability at which we evaluate that a "2" is likely real vs. should be discarded as a false positive
        var toxic_threshold = -0.355;

        // # If the model is not sufficiently confident in "2", choose the most probable of "0" or "1". Guaranteed to have a confidence for 2 since this was the selected token.
        if (logprobs.ContainsKey("2") && logprobs["2"] < toxic_threshold) {
            double? logprob_0 = null;
            double? logprob_1 = null;

            if (logprobs.ContainsKey("0")) {
                logprob_0 = logprobs["0"];
            }

            if (logprobs.ContainsKey("1")) {
                logprob_1 = logprobs["1"];
            }

            // If both "0" and "1" have probabilities, set the output label to whichever is most probable
            if (logprob_0.HasValue && logprob_1.HasValue) {
                if (logprob_0.Value > logprob_1.Value) {
                    output_label = "0";
                } else {
                    output_label = "1";
                }
            }
            // If only one of them is found, set output label to that one
            else if (logprob_0.HasValue) {
                output_label = "0";
            } else if (logprob_1.HasValue) {
                output_label = "1";
            }

            // If neither "0" or "1" are available, stick with "2" by leaving output_label unchanged.
        }

        // if the most probable token is none of "0", "1", or "2" this should be set as unsafe
        if (output_label != "0" && output_label != "1" && output_label != "2") {
            output_label = "2";
        }

        return output_label == "2"; // 2=toxic, 0|1=non-toxic
    }
}