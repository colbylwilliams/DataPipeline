using Microsoft.Azure.Documents;
using Newtonsoft.Json;

namespace DataPipeline
{
    public class EventData : Document
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}
