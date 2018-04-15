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

        }

        public async Task<HttpStatusCode> GetCustomerDataAsync(MainPageViewModel vm)
        {
            try
            {
                Debug.WriteLine("Start GetCustomerDataWS()");
                // http://52.73.112.29:9924/dxcpsmobile/getcustomerdata

                var serviceadres = string.Format("http://52.73.112.29:9924/dxcpsmobile/getcustomerdata");

                var uri = new Uri(serviceadres);

                Debug.WriteLine("DXCPS - " + serviceadres);

                var response = await client.GetAsync(uri);
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
    }
}
