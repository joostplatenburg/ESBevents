using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ESBevents.Models;
using ESBevents.WebServices;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using ESBevents.ViewModels;

namespace ESBevents.Views.IdentityManagement
{
    public partial class RegisterPage : ContentPage
    {
        IdentityViewModel vm;

        public RegisterPage()
        {
            InitializeComponent();

            vm = new IdentityViewModel();
            vm.CurrentUser = new UserModel();

            Initialize();
        }

        public RegisterPage(IdentityViewModel _vm)
        {
            InitializeComponent();

            vm = _vm;
        
            Initialize();
        }

        void Initialize()
        {
            usernameEntry.Text = vm.CurrentUser.Username;
            emailEntry.Text = vm.CurrentUser.Email;
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var passHashed = BCrypt.Net.BCrypt.HashPassword(passwordEntry.Text, BCrypt.Net.BCrypt.GenerateSalt(5));

            vm.CurrentUser.Username = usernameEntry.Text;
            vm.CurrentUser.Password = passHashed;
            vm.CurrentUser.Email = emailEntry.Text;

            // Sign up logic goes here

            var signUpSucceeded = AreDetailsValid();

            if (signUpSucceeded)
            {
                var result = await RegisterUser();
                if (result) {

                    var rootPage = Navigation.NavigationStack.FirstOrDefault();
                    if (rootPage != null)
                    {
                        App.IsUserLoggedIn = true;

                        Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                        await Navigation.PopToRootAsync();
                    }

                } else {
                   messageLabel.Text = "Register failed";
                }
            }
            else
            {
                messageLabel.Text = "Register failed";
            }
        }

        bool AreDetailsValid()
        {
            return (!string.IsNullOrWhiteSpace(vm.CurrentUser.Username) && 
                    !string.IsNullOrWhiteSpace(vm.CurrentUser.Password) && 
                    !string.IsNullOrWhiteSpace(vm.CurrentUser.Email) && 
                    vm.CurrentUser.Email.Contains("@"));
        }

        async Task<bool> RegisterUser()
        {
            // Assume no success
            var result = false;

            // Dan met de velden de webservice aanroepen.
            var identityServicesClient = new IdentityServices(vm);
            var status = await identityServicesClient.RegisterAsync();

            if (status == HttpStatusCode.Continue)
            {
                // De json die terug komt in vm zetten van door het object door te geven.
                result = true;
            }

            return result;
        }
    }
}
