using System;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

using StoryGhost.Interfaces;

namespace StoryGhost.Services;

public class DummyAnalysisService : IAnalysisService
{
    private readonly ILogger<DummyAnalysisService> _logger;
    private readonly HttpClient _httpClient;


    public DummyAnalysisService(ILogger<DummyAnalysisService> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public async Task<bool> IsToxic(string userId, string text)
    {
        return false;
    }
}