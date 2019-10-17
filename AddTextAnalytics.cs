using System;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;

namespace DataPipeline
{
    public static class AddTextAnalytics
    {
        static string _textAnalyticsKey = Environment.GetEnvironmentVariable("TextAnalyticsKey");
        static string _textAnalyticsEndpoint = Environment.GetEnvironmentVariable("TextAnalyticsEndpoint");
        
        static TextAnalyticsCredentials TextAnalyticsCredentials = new TextAnalyticsCredentials(_textAnalyticsKey);
        static TextAnalyticsClient TextAnalyticsClient = new TextAnalyticsClient(TextAnalyticsCredentials) { Endpoint = _textAnalyticsEndpoint };

        [FunctionName(nameof(AddTextAnalytics))]
        public static void Run(
            [QueueTrigger("event-queue")]EventData meessage,
            [CosmosDB("Data", "Events", Id = "{id}", PartitionKey = "{location}", ConnectionStringSetting = "CosmosDBConnection")]EventData eventData, ILogger log)
        {
            var sentimentResult = TextAnalyticsClient.Sentiment(eventData.Description);

            eventData.Sentiment = sentimentResult.Score;
        }
    }
}
