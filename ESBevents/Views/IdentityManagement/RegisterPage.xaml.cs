using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ESBevents.Models;
using ESBevents.WebServices;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

namespace ESBevents.Views.IdentityManagement
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var passHashed = BCrypt.Net.BCrypt.HashPassword(passwordEntry.Text, BCrypt.Net.BCrypt.GenerateSalt(5));

            var user = new UserModel()
            {
                Username = usernameEntry.Text,
                Password = passHashed,
                Email = emailEntry.Text
            };

            // Sign up logic goes here

            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded)
            {
                var result = await RegisterUser(user);
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

        bool AreDetailsValid(UserModel user)
        {
            return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        }

        async Task<bool> RegisterUser(UserModel user)
        {
            // Assume no success
            var result = false;

            // Dan met de velden de webservice aanroepen.
            var identityServicesClient = new IdentityServices();
            var status = await identityServicesClient.RegisterAsync(user);

            if (status == HttpStatusCode.Continue)
            {
                // De json die terug komt in vm zetten van door het object door te geven.
                result = true;
            }

            return result;
        }
    }
}
