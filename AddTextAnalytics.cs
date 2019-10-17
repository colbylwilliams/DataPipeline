using System;

using Microsoft.Azure.WebJobs;
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
            [QueueTrigger("event-queue")]EventData message,
            [CosmosDB("Data", "Events", Id = "{id}", PartitionKey = "{location}", ConnectionStringSetting = "CosmosDBConnection")]EventData eventData, ILogger log)
        {
            if (eventData != null)
            {
                var sentimentResult = TextAnalyticsClient.Sentiment(eventData.Description);
                eventData.Sentiment = sentimentResult.Score;

            } else {
                throw new ArgumentNullException($"Could not find Event with id: {message.Id} and partitionKey: {message.Location}");
            }
        }
    }
}
