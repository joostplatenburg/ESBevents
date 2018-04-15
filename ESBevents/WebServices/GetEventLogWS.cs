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
using System.Net.Http;

namespace ESBevents.WebServices
{
    public class GetEventLogWS
    {
        readonly HttpClient client;

        public GetEventLogWS()
        {
            client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;

        }

        public async Task<HttpStatusCode> GetEventLogAsync(CustomerViewModel vm)
        {
            try
            {
                Debug.WriteLine("Start GetEventLog()");

                Debug.WriteLine(vm.Name);
                Debug.WriteLine(vm.Environment);
                Debug.WriteLine(vm.Customer.IPT);
                Debug.WriteLine(vm.Customer.PortEnsemble);

                var service = "http://{0}:{1}/DXCUtilities/HaalEventlog";
                var serviceadres = string.Empty;

                Debug.WriteLine(service);

                switch (vm.Environment)
                {
                    case "Ontwikkel":
                        serviceadres = string.Format(service, vm.Customer.IPO, vm.Customer.PortEnsemble);
                        break;
                    case "Test":
                        serviceadres = string.Format(service, vm.Customer.IPT, vm.Customer.PortEnsemble);
                        break;
                    case "Acceptatie":
                        serviceadres = string.Format(service, vm.Customer.IPA, vm.Customer.PortEnsemble);
                        break;
                    case "Productie":
                        serviceadres = string.Format(service, vm.Customer.IPP, vm.Customer.PortEnsemble);
                        break;
                }

                var uri = new Uri(serviceadres);

                var response = await client.GetAsync(uri);
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return HttpStatusCode.BadRequest;
            }
        }
    }
}
