using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


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
                var events = input.Select(i => JsonConvert.DeserializeObject<EventData>(JsonConvert.SerializeObject(i)));

                foreach (var e in events)
                {
                    log.LogInformation(e.Title);
                }

                log.LogInformation("Documents modified " + input.Count);
            }
        }
    }
}
