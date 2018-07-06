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
    public class GetCustomerDataWS
    {
        readonly HttpClient client;

        public GetCustomerDataWS()
        {
            client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;
            client.BaseAddress = new Uri("http://52.73.112.29:58002");

        }

        public async Task<HttpStatusCode> GetCustomersAsync(MainPageViewModel vm)
        {
            try
            {
                Debug.WriteLine("Start GetCustomersAsync()");

                var service = string.Format("pubsub/getcustomers");

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = await client.GetAsync(service);

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var json = response.Content.ReadAsStringAsync().Result;

                    Debug.WriteLine(json);

                    var Customers = JsonConvert.DeserializeObject<List<CustomerModel>>(json);

                    vm.Customers = new List<CustomerModel>();
                    foreach (CustomerModel cm in Customers)
                    {
                        vm.Customers.Add(cm);
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

        public async Task<HttpStatusCode> GetCustomerAsync(CustomerViewModel cvm, string customerid)
        {
            try
            {
                Debug.WriteLine("Start GetCustomerAsync()");

                var service = string.Format("pubsub/getcustomer?customer={0}", customerid);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = await client.GetAsync(service);

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var json = response.Content.ReadAsStringAsync().Result;

                    Debug.WriteLine(json);

                    var Customer = JsonConvert.DeserializeObject<CustomerModel>(json);

                    if (Customer != null)
                    {
                        cvm.Customer = Customer;
                        cvm.Customers = new List<CustomerModel>();
                        cvm.Customers.Add(Customer);
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
