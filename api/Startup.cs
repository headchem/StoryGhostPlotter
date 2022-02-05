using System;
using System.Net;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Polly;
using Polly.Retry;
using Microsoft.Extensions.Http;
using Polly.Extensions.Http;

using StoryGhost.Interfaces;
using StoryGhost.Services;

[assembly: FunctionsStartup(typeof(MyNamespace.Startup))]

namespace MyNamespace
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // exponential backoff with the following attempts - TODO: log error if exceeding attempts, handle gracefully in UI
            var exponentialBackoff = GetRetryPolicy();
            var longTimeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(500));

            var combinedExpLongPolicy = longTimeoutPolicy.WrapAsync(exponentialBackoff);

            // builder.Services.AddHttpClient<ICompletionService, OpenAICompletionService>()
            //     .SetHandlerLifetime(TimeSpan.FromSeconds(500))
            //     .AddPolicyHandler(combinedExpLongPolicy);

            // use below for testing the UI without using up real completions
            builder.Services.AddHttpClient<ICompletionService, DummyCompletionService>();


            builder.Services.AddApplicationInsightsTelemetry();


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
                            //var test = "got an exception... log more here?";
                            //Log($"Too many requests. Retrying in {sleepDuration}. {attemptNumber} / {MAX_RETRIES}");
                        }
                );
        }
    }
}