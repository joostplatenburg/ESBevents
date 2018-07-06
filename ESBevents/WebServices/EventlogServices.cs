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
    public class EventlogServices
    {
        readonly HttpClient client;

        public EventlogServices()
        {
            client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;

        }

        public async Task<HttpStatusCode> GetEventlogAsync(CustomerViewModel vm)
        {
            try
            {
                Debug.WriteLine("Start GetEventLog()");

                Debug.WriteLine(vm.Name);
                Debug.WriteLine(vm.Environment);
                Debug.WriteLine(vm.Customer.IPT);
                Debug.WriteLine(vm.Customer.PortEnsemble);

                var service = "http://{0}:{1}/dxcmobile/geteventlog";
                var serviceadres = string.Empty;

                Debug.WriteLine(service);

                switch (vm.Environment)
                {
                    case "Test":
                        serviceadres = string.Format(service, vm.Customer.IPT, vm.Customer.PortEnsemble);
                        break;
                    case "Acceptatie":
                        serviceadres = string.Format(service, vm.Customer.IPA, vm.Customer.PortEnsemble);
                        break;
                    case "Productie":
                        serviceadres = string.Format(service, vm.Customer.IPP, vm.Customer.PortEnsemble);
                        break;
                    default:
                        break;
                }

                serviceadres = string.Format("http://{0}:{1}/pubsub/geteventlog", "52.73.112.29", "58002");
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
