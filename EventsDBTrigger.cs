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
        public static void Run(
            [CosmosDBTrigger("Data","Events", ConnectionStringSetting = "CosmosDBConnection")]IReadOnlyList<Document> input,
            [Queue("event-queue")] ICollector<EventData> eventMessages, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                var events = input.Select(i => JsonConvert.DeserializeObject<EventData>(JsonConvert.SerializeObject(i))).Where(e => !e.HasAnalytics);
                
                foreach (var e in events)
                    eventMessages.Add(e);
            }
        }
    }
}
