using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ESBevents.Models
{
    public class IdentityModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime? Created { get; set; }

        [JsonProperty(PropertyName = "changed")]
        public DateTime? Changed { get; set; }

        [JsonProperty(PropertyName = "lastlogin")]
        public DateTime? LastLogin { get; set; }

        [JsonProperty(PropertyName = "approved")]
        public bool? Approved { get; set; }

        [JsonProperty(PropertyName = "approvedon")]
        public DateTime? ApprovedOn { get; set; }

        [JsonProperty(PropertyName = "customerid")]
        public string CustomerId { get; set; }

        [JsonProperty(PropertyName = "customername")]
        public string Customername { get; set; }

        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "sessiontoken")]
        public string Sessiontoken { get; set; }

        [JsonProperty(PropertyName = "numberofsessions")]
        public int NumberOfSessions { get; set; }

        [JsonProperty(PropertyName = "sessions")]
        public ObservableCollection<SessionModel> Sessions { get; set; }

        [JsonConstructor]
        public IdentityModel()
        {
            Sessions = new ObservableCollection<SessionModel>();
        }
    }
}
