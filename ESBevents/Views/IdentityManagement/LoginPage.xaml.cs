using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BCrypt.Net;
using ESBevents.Models;
using System.Linq;
using ESBevents.WebServices;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using ESBevents.ViewModels;

namespace ESBevents.Views.IdentityManagement
{
    public partial class LoginPage : ContentPage
    {
        IdentityViewModel vm;

        public LoginPage()
        {
            InitializeComponent();
            vm = new IdentityViewModel();
            vm.CurrentUser = new UserModel();
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

                        var rootPage = Navigation.NavigationStack.FirstOrDefault();
                        if (rootPage != null)
                        {
                            App.IsUserLoggedIn = true;

                            if (string.IsNullOrWhiteSpace(App.CurrentUser.CustomerId))
                            {

                                Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());

                            } else {

                                Navigation.InsertPageBefore(new CustomerView(), Navigation.NavigationStack.First());

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
                    messageLabel.Text = "Login failed";
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
            await Navigation.PushAsync(new RegisterPage(vm));
        }

        async void OnChangeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePassword(vm));
        }

        async void OnForgotButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Forgot Password", "Not Implemented Yet", "OK");

            // 1. Remove Identity through webservice
            //

            // 2. Reregister
            //
        }
    }
}
