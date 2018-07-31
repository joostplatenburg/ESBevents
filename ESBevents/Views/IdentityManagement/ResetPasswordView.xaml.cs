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
    public partial class ResetPasswordView : ContentPage
    {
        ResetPasswordViewModel vm;

        public ResetPasswordView()
        {
            InitializeComponent();

            vm = new ResetPasswordViewModel();
            vm.CurrentUser = new IdentityModel();

            Initialize();
        }

        public ResetPasswordView(LoginViewModel _vm)
        {
            InitializeComponent();

            vm = new ResetPasswordViewModel();
            vm.CurrentUser = _vm.CurrentUser;
        
            Initialize();
        }

        void Initialize()
        {
            usernameEntry.Text = vm.CurrentUser.Username;
            vm.ShowCodeStack = false;
        }

        async void OnAskCodeButtonClicked(object sender, EventArgs e)
        {
            vm.CurrentUser.Username = usernameEntry.Text;

            // newpassword filled and confirmed
            if (AreDetailsValid1())
            {
                // 1. get a code from the server
                var result = await vm.GetResetCode();

                messageLabel.Text = string.Format("Request for code send to emailaddress of user {0}", vm.CurrentUser.Username);

            }
            else
            {
                messageLabel.Text = "Request for code needs at least an username";
            }
        }

        async void OnResetButtonClicked(object sender, EventArgs e)
        {

            vm.CurrentUser.Username = usernameEntry.Text;
            vm.CurrentUser.Password = codeEntry.Text;

            // newpassword filled and confirmed
            if (AreDetailsValid2())
            {
                // 1. get currentcode
                //

                var identity = await vm.GetIdentityAsync();

                if (!string.IsNullOrWhiteSpace(identity.ResetCode) && identity.ResetCode == codeEntry.Text)
                {
                        // 2. create hash for new password
                    var newPassHashed = BCrypt.Net.BCrypt.HashPassword(newPassword1Entry.Text, BCrypt.Net.BCrypt.GenerateSalt(5));

                    vm.NewPasswordHashed = newPassHashed;

                    // 3. Now update password
                    var result = await vm.ChangePasswordAsync();
                    if (result)
                    {
                        App.IsUserLoggedIn = true;

                        Navigation.InsertPageBefore(new LoginView(), Navigation.NavigationStack.First());
                        await Navigation.PopToRootAsync();
                    }
                } else {
                    messageLabel.Text = "Reset Code not known on server";
                }
            }
            else
            {
                messageLabel.Text = "No new Password(s) entered or entered Passwords differ";
            }
        }

        bool AreDetailsValid1()
        {
            return (!string.IsNullOrWhiteSpace(vm.CurrentUser.Username));
        }

        bool AreDetailsValid2()
        {
            return (
                    !string.IsNullOrWhiteSpace(vm.CurrentUser.Username) &&
                    !string.IsNullOrWhiteSpace(vm.CurrentUser.Password) &&
                    !string.IsNullOrWhiteSpace(newPassword1Entry.Text) &&
                    !string.IsNullOrWhiteSpace(newPassword2Entry.Text) &&
                    newPassword1Entry.Text == newPassword2Entry.Text
                   );
        }
    }
}
