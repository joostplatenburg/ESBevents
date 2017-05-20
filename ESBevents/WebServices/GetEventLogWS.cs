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

		public async Task<HttpStatusCode> GetEventLogAsync(CustomerViewModel vm)
        {
            try
            {
                Debug.WriteLine("Start GetEventLog()");

                var client = new System.Net.Http.HttpClient();

                Debug.WriteLine(vm.Name);
                Debug.WriteLine(vm.Key);

                switch (vm.Key)
                {
                    case "Ontwikkel":
                        client.BaseAddress = new Uri(string.Format("http://{0}:{1}/DXCUtilities/", vm.Customer.IPNumberO, vm.Customer.PortNumberEL));
                        break;
					case "Test":
						client.BaseAddress = new Uri(string.Format("http://{0}:{1}/DXCUtilities/", vm.Customer.IPNumberT, vm.Customer.PortNumberEL));
						break;
					case "Acceptatie":
						client.BaseAddress = new Uri(string.Format("http://{0}:{1}/DXCUtilities/", vm.Customer.IPNumberA, vm.Customer.PortNumberEL));
						break;
					case "Productie":
						client.BaseAddress = new Uri(string.Format("http://{0}:{1}/DXCUtilities/", vm.Customer.IPNumberP, vm.Customer.PortNumberEL));
						break;
				}

                var command = "HaalEventlog";

				Debug.WriteLine(client.BaseAddress + command);

				var response = await client.GetAsync(command);
                //var requestTask = client.GetAsync(command); 
                //var response = Task.Run(() => requestTask);

				if (response.StatusCode == HttpStatusCode.Continue ||
					response.StatusCode == HttpStatusCode.Accepted ||
					response.StatusCode == HttpStatusCode.OK)
				{
					var eventlogJson = response.Content.ReadAsStringAsync().Result;

                	//Debug.WriteLine(eventlogJson);

					var EventLogs = JsonConvert.DeserializeObject<List<List<EventModel>>>(eventlogJson);

					vm.Eventlog = EventLogs[0];

					if (vm.Eventlog.Count > 0)
					{
						vm.Event = vm.Eventlog.First();
					}

					return HttpStatusCode.Continue;
				}
				return response.StatusCode;
            }
            catch (System.Net.WebException)
            {
				return HttpStatusCode.InternalServerError;
            }
        }
    }
}
