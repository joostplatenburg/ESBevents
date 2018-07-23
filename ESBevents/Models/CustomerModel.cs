using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESBevents.Models
{
    public class CustomerModel
    {
        [JsonProperty(PropertyName = "identifier")]
        public string Identifier { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "logo")]
        public string Logo { get; set; }

        [JsonProperty(PropertyName = "ipt")]
        public string IPT { get; set; }

        [JsonProperty(PropertyName = "ipa")]
        public string IPA { get; set; }

        [JsonProperty(PropertyName = "ipp")]
		public string IPP { get; set; }

        [JsonProperty(PropertyName = "portensemble")]
        public string PortEnsemble { get; set; } // Eventlog

        [JsonProperty(PropertyName = "portpubsub")]
		public string PortPubsub { get; set; } // StartProcess

        [JsonProperty(PropertyName = "toonstartbp")]
        public bool? ToonStartBP { get; set; }

        [JsonProperty(PropertyName = "tooneventlog")]
        public bool? ToonEventlog { get; set; }

        [JsonProperty(PropertyName = "toonpslog")]
        public bool? ToonPSlog { get; set; }

        [JsonProperty(PropertyName = "koppelingen")]
        public List<KoppelingModel> Koppelingen { get; set; }

        [JsonProperty(PropertyName = "showinmaslist")]
        public bool? ShowInMASList { get; set; }

        [JsonConstructor]
        public CustomerModel()
        {
            //Identifier  = string.Empty;
            //Name        = string.Empty;
            //Logo        = string.Empty;
            //IPT         = string.Empty;
            //IPA         = string.Empty;
            //IPP         = string.Empty;
            //PortEnsemble    = string.Empty;
            //PortPubsub      = string.Empty;
            //ToonPSlog       = true;
            //ToonStartBP     = true;
            //ToonEventlog    = true;
            //Koppelingen = new List<KoppelingModel>();
        }
	}
}
