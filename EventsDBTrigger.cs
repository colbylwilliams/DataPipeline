using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace DataPipeline
{
    public static class EventsDBTrigger
    {
        [FunctionName(nameof(EventsDBTrigger))]
        public static void Run([CosmosDBTrigger(
            databaseName: "Data",
            collectionName: "Events",
            CreateLeaseCollectionIfNotExists = true,
            ConnectionStringSetting = "colbydatapipeline")]IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
            }
        }
    }
}
