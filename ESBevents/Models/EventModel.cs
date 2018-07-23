using Newtonsoft.Json;

namespace ESBevents.Models
{
    public class EventModel
    {
        [JsonProperty(PropertyName = "configname")]
        public string ConfigName { get; set; }

        [JsonProperty(PropertyName = "job")]
        public string Job { get; set; }

        [JsonProperty(PropertyName = "messageid")]
        public int? MessageId { get; set; }

        [JsonProperty(PropertyName = "sessionid")]
        public string SessionId { get; set; }

        [JsonProperty(PropertyName = "sourceclass")]
        public string SourceClass { get; set; }

        [JsonProperty(PropertyName = "sourcemethod")]
        public string SourceMethod { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "timelogged")]
        public string TimeLogged { get; set; }

        [JsonProperty(PropertyName = "tracecat")]
        public string TraceCat { get; set; }

        [JsonProperty(PropertyName = "type")]
        public int? Type { get; set; }

        [JsonConstructor]
        public EventModel()
        {
            
        }
	}
}