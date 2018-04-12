using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBevents.Models
{
    public class DeliveryModel
    {
        public string DeliveryId { get; set; }
        public string MessageId { get; set; }
        public string CreationDate { get; set; }
        public string CreationTime { get; set; }
        public string ProcessedDate { get; set; }
        public string ProcessedTime { get; set; }
        public string SubscriptionStatus { get; set; }
        public string DeliveryStatus { get; set; }
        public string NumberOfTries { get; set; }
        public string Resultmessage { get; set; }
        public string PublisherName { get; set; }
        public string SubscriptionName { get; set; }
        public string MessageType { get; set; }
        public string Messagecontent { get; set; }
	}
}
