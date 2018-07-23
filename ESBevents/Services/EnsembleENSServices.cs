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
using System.Collections.ObjectModel;

namespace ESBevents.Services
{
    public class EnsembleENSServices
    {
        readonly HttpClient client;

        ActionsViewModel customervm = new ActionsViewModel();

        CustomerModel customer;

        string environment;

        public EnsembleENSServices(ActionsViewModel _vm)
        {
            customervm = _vm;

            client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;

            customer = _vm.Customer;
            environment = _vm.Environment;
        
            Initialize();
        }

        private void Initialize()
        {
             
            switch (environment)
            {
                case "Test":
                    client.BaseAddress = new Uri(string.Format("http://{0}:{1}", "52.73.112.29", "58002" )); //customer.IPT, customer.PortEnsemble));
                    break;
                case "Acceptatie":
                    client.BaseAddress = new Uri(string.Format("http://{0}:{1}", customer.IPA, customer.PortEnsemble));
                    break;
                case "Productie":
                    client.BaseAddress = new Uri(string.Format("http://{0}:{1}", customer.IPP, customer.PortEnsemble));
                    break;
                default:
                    client.BaseAddress = null;
                    break;
            }

        }
        public async Task<HttpStatusCode> GetEventlogAsync()
        {
            try
            {
                Debug.WriteLine("DXCPS - Start GetEventLog()");

                var service = "pubsub/geteventlog";

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = await client.GetAsync(service);

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var json = response.Content.ReadAsStringAsync().Result;

                    Debug.WriteLine(json);

                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        customervm.Eventlog = new ObservableCollection<EventModel>();

                        customervm.Eventlog = JsonConvert.DeserializeObject<ObservableCollection<EventModel>>(json) as ObservableCollection<EventModel>;
                    }
                    /*
                        customervm.Eventlog = EventLogs[0];

                        if (customervm.Eventlog.Count > 0)
                        {
                            customervm.Event = customervm.Eventlog.First();
                        }
                    }
                    */
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
