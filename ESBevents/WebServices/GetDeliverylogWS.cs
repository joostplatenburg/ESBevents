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
    public class GetDeliverylogWS
    {
        readonly HttpClient client;

        public GetDeliverylogWS()
        {
            client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;

        }

        public async Task<HttpStatusCode> GetDeliverylogAsync(PubsubKoppelingenViewModel vm)
        {
            try
            {
                Debug.WriteLine("Start GetDeliverylogWS()");
                // http://localhost:54326/dxcmobile/GetDeliveryLog?subscription=DZG010&status=Initial
                // http://52.73.112.29:9925/dxcpsmobile/getdeliverylog?subscription=DZG015&status=Initial

                //                Debug.WriteLine(vm.Name);
                Debug.WriteLine(vm.Status);
                Debug.WriteLine(vm.Customer.IPT);
                Debug.WriteLine(vm.Customer.PortEnsemble);

                var service = "http://{0}:{1}/dxcpsmobile/getdeliverylog?subscription={2}&status={3}";
                var serviceadres = string.Empty;

                Debug.WriteLine(service);

                switch (vm.Environment)
                {
                    case "Ontwikkel":
                        serviceadres = string.Format(service, vm.Customer.IPO, vm.Customer.PortPubsub, vm.SelectedKoppeling.Name, vm.Status);
                        break;
                    case "Test":
                        serviceadres = string.Format(service, vm.Customer.IPT, vm.Customer.PortPubsub, vm.SelectedKoppeling.Name, vm.Status);
                        break;
                    case "Acceptatie":
                        serviceadres = string.Format(service, vm.Customer.IPA, vm.Customer.PortPubsub, vm.SelectedKoppeling.Name, vm.Status);
                        break;
                    case "Productie":
                        serviceadres = string.Format(service, vm.Customer.IPP, vm.Customer.PortPubsub, vm.SelectedKoppeling.Name, vm.Status);
                        break;
                }

                var uri = new Uri(serviceadres);

                Debug.WriteLine("DXCPS - " + serviceadres);

                var response = await client.GetAsync(uri);
                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var deliverylogJson = response.Content.ReadAsStringAsync().Result;

                    Debug.WriteLine(deliverylogJson);

                    var Deliveries = JsonConvert.DeserializeObject<List<DeliveryModel>>(deliverylogJson);

                    vm.Deliveries = new System.Collections.ObjectModel.ObservableCollection<DeliveryModel>();
                    foreach (DeliveryModel dm in Deliveries)
                    {
                        vm.Deliveries.Add(dm);
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
