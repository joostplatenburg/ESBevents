﻿// ===================
// === http://localhost:58002/pubsub/checkpassword?username=jplatenb&password="aap1"
// === http://localhost:58002/pubsub/register?username=jplatenb&password="aap"&email=jplatenb@dxc.com

using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;
using ESBevents.ViewModels;
using System.Net;
using System.Net.Http;
using Xamarin.Essentials;
using System.Collections.ObjectModel;

namespace ESBevents.Services
{
    public class PubsubServices
    {
        HttpClient client;

        public PubsubServices()
        {
            Initialize();
        }

        private void Initialize()
        {
            client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;

            client.BaseAddress = new Uri("http://52.73.112.29:58002");
        }

        public async Task<HttpStatusCode> RegisterAsync(IdentityModel _currentuser)
        {
            try
            {
                Debug.WriteLine("Start RegisterAsync()");

                var service = string.Format("pubsub/register?username={0}&password={1}&email={2}", _currentuser.Username, _currentuser.Password, _currentuser.Email);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var jsonData = GetDeviceInfoJson();

                Debug.WriteLine("DXCPS - DeviceInfo: " + jsonData);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(service, content).Result;

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

        public async Task<HttpStatusCode> ApproveAsync(IdentityViewModel vm)
        {
            try
            {
                Debug.WriteLine("Start ApproveAsync()");

                var service = string.Format("pubsub/approveidentity?id={0}", vm.SelectedItem.Id);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var content = new StringContent("{}", Encoding.UTF8, "application/json");

                var response = client.PostAsync(service, content).Result;

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

        public async Task<IdentityModel> PostSessionAsync(IdentityViewModel vm)
        {
            try
            {
                Debug.WriteLine("DXCPS - Start PostSessionAsync()");

                var service = string.Format("pubsub/postsession?username={0}", vm.CurrentUser.Username);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var jsonData = GetDeviceInfoJson();

                Debug.WriteLine("DXCPS - DeviceInfo: " + jsonData);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(service, content).Result;

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        // De json die terug komt in vm zetten van door het object door te geven.
                        IdentityModel identity = JsonConvert.DeserializeObject<IdentityModel>(result);

                        App.SessionToken = identity.Sessiontoken;

                        return App.CurrentUser;
                    }
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

        public async Task<IdentityModel> PostSessionAsync(string _username)
        {
            try
            {
                Debug.WriteLine("DXCPS - Start PubsubSeervices.PostSessionAsync(" + _username + ")");

                var service = string.Format("pubsub/postsession?username={0}", _username);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var jsonData = GetDeviceInfoJson();

                Debug.WriteLine("DXCPS - DeviceInfo: " + jsonData);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(service, content).Result;

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        // De json die terug komt in vm zetten van door het object door te geven.
                        IdentityModel identity = JsonConvert.DeserializeObject<IdentityModel>(result);

                        App.SessionToken = identity.Sessiontoken;

                        return identity;
                    }
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

        public async Task<HttpStatusCode> GetIdentityExtAsync(IdentityViewModel idvm)
        {
            try
            {
                Debug.WriteLine("DXCPS - Start GetIdentityExtAsync()");

                var service = string.Format("pubsub/getidentityext?username={0}", idvm.SelectedItem.Username);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = client.GetAsync(service).Result;

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    // De json die terug komt in vm zetten van door het object door te geven.
                    IdentityModel identity = JsonConvert.DeserializeObject<IdentityModel>(result);

                    idvm.IdentityExt = identity;

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

        public async Task<IdentityModel> GetIdentityAsync(string _username)
        {
            try
            {
                Debug.WriteLine("DXCPS - Start GetIdentityAsync()");

                var service = string.Format("pubsub/getidentity?username={0}", _username);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = client.GetAsync(service).Result;

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    // De json die terug komt in vm zetten van door het object door te geven.
                    IdentityModel identity = JsonConvert.DeserializeObject<IdentityModel>(result);

                    App.CurrentUser = identity;

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

        public async Task<IdentityModel> GetIdentityAsync(LoginViewModel vm)
        {
            try
            {
                Debug.WriteLine("DXCPS - Start GetIdentityAsync()");

                var service = string.Format("pubsub/getidentity?username={0}", vm.CurrentUser.Username);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = client.GetAsync(service).Result;

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    // De json die terug komt in vm zetten van door het object door te geven.
                    IdentityModel identity = JsonConvert.DeserializeObject<IdentityModel>(result);

                    App.CurrentUser = identity;

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

        public async Task<ObservableCollection<IdentityModel>> GetIdentitiesAsync(IdentitiesViewModel identitiesvm)
        {
            try
            {
                Debug.WriteLine("DXCPS - Start GetIdentitiesAsync()");

                var service = string.Format("pubsub/getidentities");

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = client.GetAsync(service).Result;

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine(json);

                    ObservableCollection<IdentityModel> Identities = new ObservableCollection<IdentityModel>();

                    if (json != "")
                    {
                        Identities = JsonConvert.DeserializeObject<ObservableCollection<IdentityModel>>(json) as ObservableCollection<IdentityModel>;
                    }

                    return Identities;
                }

                Debug.WriteLine(response.ReasonPhrase);
                Debug.WriteLine(response.StatusCode);
                return null;
            }
            catch (System.Net.WebException)
            {
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<ObservableCollection<CustomerModel>> GetCustomersAsync()
        {
            try
            {
                Debug.WriteLine("DXCPS - Start GetCustomersAsync()");

                var service = string.Format("pubsub/getcustomers");

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = client.GetAsync(service).Result;

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine(json);

                    ObservableCollection<CustomerModel> Customers = new ObservableCollection<CustomerModel>();

                    if (json != "")
                    {
                        Customers = JsonConvert.DeserializeObject<ObservableCollection<CustomerModel>>(json) as ObservableCollection<CustomerModel>;
                    }

                    return Customers;
                }

                Debug.WriteLine(response.ReasonPhrase);
                Debug.WriteLine(response.StatusCode);
                return null;
            }
            catch (System.Net.WebException)
            {
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> GetResetCodeAsync(string _username)
        {
            try
            {
                Debug.WriteLine("DXCPS - Start GetResetCodeAsync()");

                var service = string.Format("pubsub/askinlogcode?username={0}", _username);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = client.GetAsync(service).Result;

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return true;
                }
                return false;
            }
            catch (System.Net.WebException)
            {
                Debug.WriteLine(HttpStatusCode.InternalServerError);
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<HttpStatusCode> ChangePasswordAsync(IdentityModel _currentuser, string _newpasswordhashed)
        {
            try
            {
                Debug.WriteLine("DXCPS - Start ChangePasswordAsync()");

                var service = string.Format("pubsub/changepassword?username={0}&email={1}&password={2}", 
                                            _currentuser.Username, _currentuser.Email, _newpasswordhashed);

                Debug.WriteLine("DXCPS - " + service);

                var content = new StringContent("{}", Encoding.UTF8, "application/json");

                var response = client.PutAsync(service, content).Result;

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

        public async Task<HttpStatusCode> GetCustomersAsync(MainPageViewModel mainpagevm)
        {
            try
            {
                Debug.WriteLine("DXCPS - Start GetCustomersAsync()");

                var service = string.Format("pubsub/getcustomers");

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = client.GetAsync(service).Result;

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine(json);

                    mainpagevm.CustomersAll = new ObservableCollection<CustomerModel>();

                    if (json != "")
                    {
                        mainpagevm.CustomersAll = JsonConvert.DeserializeObject<ObservableCollection<CustomerModel>>(json) as ObservableCollection<CustomerModel>;
                    }

                    return HttpStatusCode.Continue;
                }

                Debug.WriteLine(response.ReasonPhrase);
                Debug.WriteLine(response.StatusCode);
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

        public async Task<HttpStatusCode> GetCustomerAsync(ActionsViewModel customervm, string customerid)
        {
            try
            {
                Debug.WriteLine("DXCPS - PubsubServices.GetCustomerAsync()");

                var service = string.Format("pubsub/getcustomer?customer={0}", customerid);

                Debug.WriteLine("DXCPS - " + client.BaseAddress + service);

                var response = client.GetAsync(service).Result;

                if (response.StatusCode == HttpStatusCode.Continue ||
                    response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine(json);

                    var Customer = JsonConvert.DeserializeObject<CustomerModel>(json);

                    if (Customer != null)
                    {
                        customervm.Customer = Customer;
                        customervm.Customers = new ObservableCollection<CustomerModel>();
                        customervm.Customers.Add(Customer);
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

        private string GetDeviceInfoJson()
        {
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

            return JsonConvert.SerializeObject(deviceInfo);
        }
    }
}