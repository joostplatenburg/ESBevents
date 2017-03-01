using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;
using ESBevents.ViewModels;
using System.Net;

namespace ESBevents.WebServices
{
    class GetEventLogWS
    {
        public GetEventLogWS() { }

		public async Task<HttpStatusCode> GetEventLogAsync(MainPageViewModel vm)
        {
            try
            {
                Debug.WriteLine("Start GetEventLog()");

                var client = new System.Net.Http.HttpClient();

				if (Views.MainPage.BaseURL == string.Empty) {


				} else {
						                
					// Null optie 
					//client.BaseAddress = new Uri("http://www.platenburg.eu/php/zab/v1/");
					//var command = "organisation.json.php";

					//client.BaseAddress = new Uri("http://localhost:57772/psRest/hpd/");

					client.BaseAddress = new Uri(string.Format(Views.MainPage.BaseURL, vm.HttpServer, vm.HttpPort));

					//var command = string.Format("organizations?$filter=naam eq '{0}' and plaats eq '{1}'", vm.Naam, vm.Plaats);
					var command = "HaalEventlog";

					Debug.WriteLine(client.BaseAddress + command);

					var response = await client.GetAsync(command);

					if (response.StatusCode == HttpStatusCode.Continue ||
						response.StatusCode == HttpStatusCode.Accepted ||
						response.StatusCode == HttpStatusCode.OK)
					{
						var eventlogJson = response.Content.ReadAsStringAsync().Result;

	                	//Debug.WriteLine(eventlogJson);

						var EventLogs = JsonConvert.DeserializeObject<List<List<EventModel>>>(eventlogJson);

						vm.EventLog = EventLogs[0];

						if (vm.EventLog.Count > 0)
						{
							vm.Event = vm.EventLog.First();
						}

						return HttpStatusCode.Continue;
					}
					return response.StatusCode;
				}
            }
            catch (System.Net.WebException)
            {
				return HttpStatusCode.InternalServerError;
            }

			return HttpStatusCode.BadRequest;
        }
    }
}
