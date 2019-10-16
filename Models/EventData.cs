using Microsoft.Azure.Documents;

namespace DataPipeline
{
    public class EventData : Document
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}