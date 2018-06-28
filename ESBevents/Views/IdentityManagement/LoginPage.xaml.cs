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

namespace ESBevents.Views.IdentityManagement
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new UserModel()
            {
                Username = usernameEntry.Text,
            };

            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded)
            {
                // ================================================================
                // === nu heb je username en hashed password,                   ===
                // === roep service aan waarin je terug krijg Valid of Invalid  ===
                var passHashed = await GetPassword(user);
                if (!string.IsNullOrWhiteSpace(passHashed))
                {
                    ////if (global::BCrypt.Net.BCrypt.CheckPassword("password", pass)) { Console.WriteLine("Match"); } else { Console.WriteLine("Don’t Match"); }
                    if (BCrypt.Net.BCrypt.CheckPassword(passwordEntry.Text, passHashed))
                    {
                        Debug.WriteLine("Match");

                        var rootPage = Navigation.NavigationStack.FirstOrDefault();
                        if (rootPage != null)
                        {
                            App.IsUserLoggedIn = true;

                            Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
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
                messageLabel.Text = "No Username of Password entered.";
            }
        }

        bool AreDetailsValid(UserModel user)
        {
            return !string.IsNullOrWhiteSpace(user.Username);
        }

        async Task<string> GetPassword(UserModel user)
        {
            // Assume no success
            var result = string.Empty;

            // Dan met de velden de webservice aanroepen.
            var identityServicesClient = new IdentityServices();
            var hashedObj = await identityServicesClient.GetPasswordAsync(user);

            if (hashedObj != null)
            {
                if (hashedObj.Hashed != null)
                {
                    result = hashedObj.Hashed;
                }
            }

            return result;
        }
    }
}
