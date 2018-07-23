using System;
using Newtonsoft.Json;

namespace ESBevents.Models
{
    public class SessionModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "start")]
        public DateTime Start { get; set; }

        [JsonProperty(PropertyName = "sessionid")]
        public string SessionId { get; set; }

        [JsonProperty(PropertyName = "devicetype")]
        public string DeviceType { get; set; }

        [JsonProperty(PropertyName = "idiom")]
        public string Idiom { get; set; }

        [JsonProperty(PropertyName = "manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "platform")]
        public string Platform { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "versionstring")]
        public string VersionString { get; set; }
    }
}
