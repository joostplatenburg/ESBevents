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

            client.BaseAddress = new Uri("http://52.73.112.29:58002");
        }

        public async Task<HttpStatusCode> RegisterAsync()
        {
            try
            {
                Debug.WriteLine("Start RegisterAsync()");

                var service = string.Format("pubsub/register?username={0}&password={1}&email={2}", vm.CurrentUser.username, vm.CurrentUser.password, vm.CurrentUser.email);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var deviceInfo = new DeviceInfoModel
                {
                    DeviceType = DeviceInfo.DeviceType.ToString(),
                    Idiom = DeviceInfo.Idiom,
                    Manufacturer = DeviceInfo.Manufacturer,
                    Model = DeviceInfo.Model,
                    Name = DeviceInfo.Name,
                    Platform = DeviceInfo.Platform,
                    Version = DeviceInfo.Version.ToString(),
                    VersionString = DeviceInfo.VersionString
                };

                string jsonData = JsonConvert.SerializeObject(deviceInfo);

                Debug.WriteLine("DXCPS - DeviceInfo: " + jsonData);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(new Uri(service), content);

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

                var service = string.Format("pubsub/getidentity?username={0}", vm.CurrentUser.username);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = await client.GetAsync(service);

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    // De json die terug komt in vm zetten van door het object door te geven.
                    UserModel identity = JsonConvert.DeserializeObject<UserModel>(result);

                    App.CurrentUser = identity;

                    Debug.WriteLine(result);
                    Debug.WriteLine(identity.password);
                    Debug.WriteLine(identity.customerid);

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

                var service = string.Format("pubsub/changepassword?username={0}&email={1}&password={2}", 
                                            vm.CurrentUser.username, vm.CurrentUser.email, vm.CurrentUser.password);

                Debug.WriteLine("DXCPS - " + service);

                var response = await client.GetAsync(service);

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
