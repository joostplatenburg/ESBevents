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
    public class EnsemblePSServices
    {
        readonly HttpClient client;

        PubsubKoppelingenViewModel koppelingenvm = new PubsubKoppelingenViewModel();
        DeliveryViewModel deliveryvm = new DeliveryViewModel();

        CustomerModel customer;
        string environment;

        public EnsemblePSServices(PubsubKoppelingenViewModel _vm)
        {
            koppelingenvm = _vm;

            client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;

            customer = _vm.Customer;
            environment = _vm.Environment;
            Initialize();
        }

        public EnsemblePSServices(DeliveryViewModel _vm)
        {
            deliveryvm = _vm;

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
                    client.BaseAddress = new Uri(string.Format("http://{0}:{1}", customer.IPT, customer.PortPubsub));
                    break;
                case "Acceptatie":
                    client.BaseAddress = new Uri(string.Format("http://{0}:{1}", customer.IPA, customer.PortPubsub));
                    break;
                case "Productie":
                    client.BaseAddress = new Uri(string.Format("http://{0}:{1}", customer.IPP, customer.PortPubsub));
                    break;
                default:
                    client.BaseAddress = null;
                    break;
            }

        }

        public async Task<HttpStatusCode> GetDeliverylogAsync()
        {
            try
            {
                Debug.WriteLine("DXCPS - Start GetDeliverylogAsync()");

                string service = string.Format("pubsub/getdeliverylog?subscription={0}&status={1}", koppelingenvm.SelectedKoppeling.Name, koppelingenvm.Status);

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
                        koppelingenvm.Deliveries = new ObservableCollection<DeliveryModel>();

                        koppelingenvm.Deliveries = JsonConvert.DeserializeObject<ObservableCollection<DeliveryModel>>(json) as ObservableCollection<DeliveryModel>;
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

        public async Task<HttpStatusCode> ResendMessageAsync()
        {
            try
            {
                Debug.WriteLine("Start ResendMessageAsync()");

                var service = string.Format("pubsub/startsingle?deliveryid={0}", deliveryvm.DeliveryId);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = await client.PostAsync(service, null);

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine(result);
                    // ===========================================================
                    // === All went well, now refresh ViewModel

                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        var updatedDelivery = JsonConvert.DeserializeObject<DeliveryModel>(result);

                        deliveryvm.Delivery.DeliveryStatus = updatedDelivery.DeliveryStatus;
                        deliveryvm.Delivery.NumberOfTries = updatedDelivery.NumberOfTries;
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

        public async Task<HttpStatusCode> SetObsoleteAsync()
        {
            try
            {
                Debug.WriteLine("DXCPS - Start SetObsoleteAsync()");

                var service = string.Format("pubsub/setobsolete?deliveryid={0}", deliveryvm.DeliveryId);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = await client.PutAsync(service, null);

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine(result);
                    // ===========================================================
                    // === All went well, now refresh ViewModel
                    if (!string.IsNullOrWhiteSpace(result))
                   {
                        var updatedDelivery = JsonConvert.DeserializeObject<DeliveryModel>(result);

                        deliveryvm.Delivery.DeliveryStatus = updatedDelivery.DeliveryStatus;
                        deliveryvm.Delivery.NumberOfTries = updatedDelivery.NumberOfTries;
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

        public async Task<HttpStatusCode> ResetRetriesAsync()
        {
            try
            {
                Debug.WriteLine("DXCPS - Start ResetRetriesAsync()");

                var service = string.Format("pubsub/resetretry?deliveryid={0}", deliveryvm.DeliveryId);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = await client.PutAsync(service, null);

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine(result);
                    // ===========================================================
                    // === All went well, now refresh ViewModel
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        var updatedDelivery = JsonConvert.DeserializeObject<DeliveryModel>(result);

                        deliveryvm.Delivery.NumberOfTries = updatedDelivery.NumberOfTries;
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
