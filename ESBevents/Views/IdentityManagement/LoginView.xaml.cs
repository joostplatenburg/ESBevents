using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BCrypt.Net;
using ESBevents.Models;
using System.Linq;
using ESBevents.Services;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using ESBevents.ViewModels;
using Xamarin.Essentials;

namespace ESBevents.Views.IdentityManagement
{
    public partial class LoginView : ContentPage
    {
        LoginViewModel vm;

        public LoginView()
        {
            InitializeComponent();

            vm = new LoginViewModel
            {
                CurrentUser = new IdentityModel(),
                CurrentVersion = string.Format("{0}.{1}", VersionTracking.CurrentVersion, VersionTracking.CurrentBuild) 
            };

            BindingContext = vm;
       }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            vm.CurrentUser.Username = usernameEntry.Text;

            var signUpSucceeded = AreDetailsValid();
            if (signUpSucceeded)
            {
                // ========================================================================
                // === nu heb je username en hashed password,                           ===
                // === roep service aan waarin je het gehashte password terug krijgt    ===
                var identity = await vm.GetIdentityAsync();

                if (!string.IsNullOrWhiteSpace(identity))
                {
                    // === nu de bestaande hash laten controleren op juistheid          ===
                    if (BCrypt.Net.BCrypt.CheckPassword(passwordEntry.Text, identity))
                    {
                        Debug.WriteLine("Match");

                        // === Now get SessionId from server to authenticate this sessions api calls
                        App.SessionToken = vm.PostSessionAsync().Result;
                        //

                        var rootPage = Navigation.NavigationStack.FirstOrDefault();
                        if (rootPage != null)
                        {
                            App.IsUserLoggedIn = true;

                            if (string.IsNullOrWhiteSpace(App.CurrentUser.CustomerId) || App.CurrentUser.CustomerId == "DXC")
                            {

                                Navigation.InsertPageBefore(new MainPageView(), Navigation.NavigationStack.First());

                            } else {

                                Debug.WriteLine("DXCPS - LoginView.OnLoginButtonClicked()");

                                Navigation.InsertPageBefore(new ActionsView(), Navigation.NavigationStack.First());

                            }
                            await Navigation.PopToRootAsync();
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Login failed");
                    }
                }
                else
                {
                    messageLabel.Text = "Login failed, no connection with the server";
                }
            }
            else
            {
                messageLabel.Text = "No Username or Password entered.";
            }
        }

        bool AreDetailsValid()
        {
            return !string.IsNullOrWhiteSpace(vm.CurrentUser.Username);
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterView(vm));
        }

        async void OnChangeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePasswordView(vm));
        }

        async void OnForgotButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResetPasswordView(vm));
        }
    }
}
