// ===================
// === http://localhost:58002/pubsub/checkpassword?username=jplatenb&password="aap1"
// === http://localhost:58002/pubsub/register?username=jplatenb&password="aap"&email=jplatenb@dxc.com

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
using Xamarin.Forms;
using Xamarin.Essentials;

namespace ESBevents.WebServices
{
    public class IdentityServices
    {
        readonly HttpClient client;
        readonly IdentityViewModel vm;

        public IdentityServices(IdentityViewModel _vm)
        {
            client = new HttpClient();
            vm = _vm;

            //client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<HttpStatusCode> RegisterAsync()
        {
            try
            {
                Debug.WriteLine("Start RegisterAsync()");
                // http://localhost:54326/dxcmobile/GetDeliveryLog?subscription=DZG010&status=Initial
                // http://52.73.112.29:9925/dxcpsmobile/getdeliverylog?subscription=DZG015&status=Initial

                var server = "52.73.112.29";
                var port = "58002";

                var service = string.Format("http://{0}:{1}/pubsub/register?username={2}&password={3}&email={4}", server, port, vm.CurrentUser.Username, vm.CurrentUser.Password, vm.CurrentUser.Email);
                var uri = new Uri(service);

                Debug.WriteLine("DXCPS - " + service);

                var response = await client.PostAsync(uri, null);
                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine(result);

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

        public async Task<UserModel> GetIdentityAsync()
        {
            try
            {
                Debug.WriteLine("Start CheckPasswordAsync()");

                var service = string.Format("http://52.73.112.29:58002/pubsub/getidentity?username={0}", vm.CurrentUser.Username);
                var uri = new Uri(service);

                Debug.WriteLine("DXCPS - " + service);

                var response = await client.GetAsync(uri);
                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    // De json die terug komt in vm zetten van door het object door te geven.
                    UserModel identity = JsonConvert.DeserializeObject<UserModel>(result);

                    App.CurrentUser = identity;

                    Debug.WriteLine(result);
                    Debug.WriteLine(identity.Password);

                    return App.CurrentUser;
                }
                return null;
            }
            catch (System.Net.WebException)
            {
                Debug.WriteLine(HttpStatusCode.InternalServerError);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<HttpStatusCode> ChangePasswordAsync()
        {
            try
            {
                Debug.WriteLine("Start CheckPasswordAsync()");
                var server = "52.73.112.29";
                var port = "58002";

                var service = string.Format("http://{0}:{1}/pubsub/changepassword?username={2}&email={3}&password={4}", 
                                            server, port, vm.CurrentUser.Username, vm.CurrentUser.Email, vm.CurrentUser.Password);
                var uri = new Uri(service);

                Debug.WriteLine("DXCPS - " + service);

                var response = await client.GetAsync(uri);
                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine(result);

                    return HttpStatusCode.Continue;
                }
                return response.StatusCode;
            }
            catch (System.Net.WebException)
            {
                Debug.WriteLine(HttpStatusCode.InternalServerError);
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
