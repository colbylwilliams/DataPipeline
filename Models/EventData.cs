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

        [JsonProperty("sentiment")]
        public double? Sentiment { get; set; }

        public bool HasAnalytics => Sentiment.HasValue;
    }
}
    // public class TextAnalytics
    // {
    //     [JsonProperty("languageDetection")]
    //     public LanguageDetection LanguageDetection { get; set; }

    //     [JsonProperty("keyPhrases")]
    //     public KeyPhrases KeyPhrases { get; set; }

    //     [JsonProperty("sentiment")]
    //     public Sentiment Sentiment { get; set; }

    //     [JsonProperty("entities")]
    //     public Entities Entities { get; set; }
    // }

    // public class Entities
    // {
    //     [JsonProperty("documents")]
    //     public List<EntitiesDocument> Documents { get; set; }

    //     [JsonProperty("errors")]
    //     public List<object> Errors { get; set; }
    // }

    // public class EntitiesDocument
    // {
    //     [JsonProperty("id")]
    //     public Guid Id { get; set; }

    //     [JsonProperty("entities")]
    //     public List<Entity> Entities { get; set; }
    // }

    // public class Entity
    // {
    //     [JsonProperty("name")]
    //     public string Name { get; set; }

    //     [JsonProperty("matches")]
    //     public List<Match> Matches { get; set; }

    //     [JsonProperty("wikipediaLanguage")]
    //     public string WikipediaLanguage { get; set; }

    //     [JsonProperty("wikipediaId")]
    //     public string WikipediaId { get; set; }

    //     [JsonProperty("wikipediaUrl")]
    //     public Uri WikipediaUrl { get; set; }

    //     [JsonProperty("bingId")]
    //     public Guid? BingId { get; set; }

    //     [JsonProperty("type")]
    //     public string Type { get; set; }

    //     [JsonProperty("subType")]
    //     public string SubType { get; set; }
    // }

    // public class Match
    // {
    //     [JsonProperty("text")]
    //     public string Text { get; set; }

    //     [JsonProperty("offset")]
    //     public long Offset { get; set; }

    //     [JsonProperty("length")]
    //     public long Length { get; set; }
    // }

    // public class KeyPhrases
    // {
    //     [JsonProperty("documents")]
    //     public List<KeyPhrasesDocument> Documents { get; set; }

    //     [JsonProperty("errors")]
    //     public List<object> Errors { get; set; }
    // }

    // public class KeyPhrasesDocument
    // {
    //     [JsonProperty("id")]
    //     public Guid Id { get; set; }

    //     [JsonProperty("keyPhrases")]
    //     public List<string> KeyPhrases { get; set; }
    // }

    // public class LanguageDetection
    // {
    //     [JsonProperty("documents")]
    //     public List<LanguageDetectionDocument> Documents { get; set; }

    //     [JsonProperty("errors")]
    //     public List<object> Errors { get; set; }
    // }

    // public class LanguageDetectionDocument
    // {
    //     [JsonProperty("id")]
    //     public Guid Id { get; set; }

    //     [JsonProperty("detectedLanguages")]
    //     public List<DetectedLanguage> DetectedLanguages { get; set; }
    // }

    // public class DetectedLanguage
    // {
    //     [JsonProperty("name")]
    //     public string Name { get; set; }

    //     [JsonProperty("iso6391Name")]
    //     public string Iso6391Name { get; set; }

    //     [JsonProperty("score")]
    //     public long Score { get; set; }
    // }

    // public class Sentiment
    // {
    //     [JsonProperty("documents")]
    //     public List<SentimentDocument> Documents { get; set; }

    //     [JsonProperty("errors")]
    //     public List<object> Errors { get; set; }
    // }

    // public class SentimentDocument
    // {
    //     [JsonProperty("id")]
    //     public Guid Id { get; set; }

    //     [JsonProperty("score")]
    //     public double Score { get; set; }
    // }

