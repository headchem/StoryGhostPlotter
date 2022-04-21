using System;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

using StoryGhost.Interfaces;
using StoryGhost.Models;
using StoryGhost.Models.Completions;
using StoryGhost.Util;
using StoryGhost.LogLine;

namespace StoryGhost.Services;

public class EncodingService : IEncodingService
{
    private readonly HttpClient _httpClient;

    public EncodingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<EncodingResponse> Encode(string text)
    {
        var req = new 
        {
            text = text
        };

        var jsonString = JsonSerializer.Serialize(req);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var funcCode = Environment.GetEnvironmentVariable("GPT_ENCODER_FUNCTION_CODE");
        var includeTokens = "false";

        var response = await _httpClient.PostAsync($"Encode?code={funcCode}&includeTokens={includeTokens}", content);
        
        if (response.IsSuccessStatusCode == false)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception(errorResponse);
        }

        var apiResponse = await response.Content.ReadAsStringAsync();
        var resultDeserialized = JsonSerializer.Deserialize<EncodingResponse>(apiResponse);

        return resultDeserialized;
    }
}