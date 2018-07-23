using System;
using Newtonsoft.Json;

namespace ESBevents.Models
{
    public class KoppelingModel
    {
        [JsonProperty(PropertyName = "externalid")]
        public string ExternalID { get; set;  }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "issubscriber")]
        public bool IsSubscriber { get; set; }

        [JsonConstructor]
        public KoppelingModel()
        {
            //ExternalID      = string.Empty;
            //Name            = string.Empty;
            //Description     = string.Empty;
        }
	}
}
