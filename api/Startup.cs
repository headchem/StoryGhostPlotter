using System;
using System.Net;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Polly;
using Polly.Retry;
using Microsoft.Extensions.Http;
using Polly.Extensions.Http;
using Microsoft.Azure.Cosmos;

using StoryGhost.Interfaces;
using StoryGhost.Services;

[assembly: FunctionsStartup(typeof(MyNamespace.Startup))]

namespace MyNamespace
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //builder.Services.AddHttpClient(); // injects IHttpClientFactory into the constructor of any object which avoids port exhaustion

            // inject caching layers
            // builder.Services.AddTransient<SalesforceTokenService>();
            // builder.Services.AddTransient<ISalesforceTokenService, CachedSalesforceTokenService>();

            var isDebug = false; // toggle the dummy completion service or the real OpenAI service

            if (isDebug == false)
            {
                // exponential backoff with the following attempts - TODO: log error if exceeding attempts, handle gracefully in UI
                var exponentialBackoff = GetRetryPolicy();
                var longTimeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(500));

                var combinedExpLongPolicy = longTimeoutPolicy.WrapAsync(exponentialBackoff);

                builder.Services.AddHttpClient<ICompletionService, OpenAICompletionService>(c =>
                {
                    c.BaseAddress = new System.Uri("https://api.openai.com/v1/");
                    c.Timeout = TimeSpan.FromMinutes(5); // default is 100 sec
                    c.DefaultRequestHeaders.Add("Accept", "application/json");

                    var openAIKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
                    c.DefaultRequestHeaders.Add("Authorization", "Bearer " + openAIKey);
                })
                    .SetHandlerLifetime(TimeSpan.FromSeconds(500))
                    .AddPolicyHandler(combinedExpLongPolicy);

                builder.Services.AddHttpClient<IEncodingService, EncodingService>(c =>
                {
                    c.BaseAddress = new System.Uri("https://sg-gpt-encoder.azurewebsites.net/api/");
                    c.Timeout = TimeSpan.FromMinutes(5); // default is 100 sec
                    c.DefaultRequestHeaders.Add("Accept", "application/json");
                })
                    .SetHandlerLifetime(TimeSpan.FromSeconds(500))
                    .AddPolicyHandler(combinedExpLongPolicy);
            }
            else
            {
                // use below for testing the UI without using up real completions
                builder.Services.AddHttpClient<ICompletionService, DummyCompletionService>();

                builder.Services.AddHttpClient<IEncodingService, EncodingService>(c =>
                {
                    c.BaseAddress = new System.Uri("https://sg-gpt-encoder.azurewebsites.net/api/");
                    c.Timeout = TimeSpan.FromMinutes(1); // default is 100 sec
                    c.DefaultRequestHeaders.Add("Accept", "application/json");
                });
            }

            builder.Services.AddApplicationInsightsTelemetry();

            var cosmosDBConnection = Environment.GetEnvironmentVariable("COSMOS_DB_CONNECTION");
            builder.Services.AddSingleton<CosmosClient>(serviceProvider =>
            {
                IHttpClientFactory httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

                CosmosClientOptions cosmosClientOptions = new CosmosClientOptions
                {
                    HttpClientFactory = httpClientFactory.CreateClient,
                    ConnectionMode = ConnectionMode.Gateway,
                    SerializerOptions = new CosmosSerializationOptions()
                    {
                        PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                    },
                    //GatewayModeMaxConnectionLimit = 1000, // error: this can't be set alongside of HttpClientFactory... // https://docs.microsoft.com/en-us/azure/cosmos-db/sql/best-practice-dotnet#best-practices-when-using-gateway-mode
                    EnableContentResponseOnWrite = false // https://docs.microsoft.com/en-us/azure/cosmos-db/sql/best-practice-dotnet#best-practices-for-write-heavy-workloads
                };

                return new CosmosClient(cosmosDBConnection, cosmosClientOptions);
            });


            // examples below for other injections

            //builder.Services.AddHttpClient<GitHubService>();

            // builder.Services.AddSingleton<IMyService>((s) => {
            //     return new MyService();
            // });

            // builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();
        }


        private IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError() // handles: HttpRequestException, HTTP 5xx, HTTP 408
                                            //.OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .OrResult(msg => msg.StatusCode == HttpStatusCode.TooManyRequests) // handles HTTP 429
                .WaitAndRetryAsync(
                    retryCount: 8, // 255 sec total (4.25 min)
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), // 1=1s, 2=2s, 3=4s, 4=8s, 5=16s, 6=32s, 7=64s, 8=128s, 9=256s
                    onRetry: (exception, sleepDuration, attemptNumber, context) =>
                        {
                            Console.WriteLine(exception.ToString());
                            //var test = "got an exception... log more here?";
                            //Log($"Too many requests. Retrying in {sleepDuration}. {attemptNumber} / {MAX_RETRIES}");
                        }
                );
        }
    }
}