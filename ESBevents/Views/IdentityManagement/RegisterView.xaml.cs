using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ESBevents.Models;
using ESBevents.Services;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using ESBevents.ViewModels;

namespace ESBevents.Views.IdentityManagement
{
    public partial class RegisterView : ContentPage
    {
        RegisterViewModel vm;

        public RegisterView()
        {
            InitializeComponent();

            vm = new RegisterViewModel();
            vm.CurrentUser = new IdentityModel();

            Initialize();
        }

        public RegisterView(LoginViewModel _vm)
        {
            InitializeComponent();

            vm = new RegisterViewModel();
            vm.CurrentUser = _vm.CurrentUser;

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
                var result = await vm.RegisterUser();
                if (result) {

                    var rootPage = Navigation.NavigationStack.FirstOrDefault();
                    if (rootPage != null)
                    {
                        App.IsUserLoggedIn = true;

                        Navigation.InsertPageBefore(new LoginView(), Navigation.NavigationStack.First());
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
    }
}
