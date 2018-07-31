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
    public partial class ChangePasswordView : ContentPage
    {
        ChangePasswordViewModel vm;

        public ChangePasswordView()
        {
            InitializeComponent();

            vm = new ChangePasswordViewModel();

            vm.CurrentUser = new IdentityModel();

            Initialize();
        }

        public ChangePasswordView(LoginViewModel _vm)
        {
            InitializeComponent();

            vm = new ChangePasswordViewModel();

            vm.CurrentUser = _vm.CurrentUser;
        
            Initialize();
        }

        void Initialize()
        {
            usernameEntry.Text = vm.CurrentUser.Username;
            emailEntry.Text = vm.CurrentUser.Email;
        }

        async void OnChangeButtonClicked(object sender, EventArgs e)
        {
            vm.CurrentUser.Username = usernameEntry.Text;
            vm.CurrentUser.Email = emailEntry.Text;
            vm.CurrentUser.Password = curPasswordEntry.Text;

            // newpassword filled and confirmed
            if (AreDetailsValid())
            {
                // 1. Check current password
                //
                var passHashed = await vm.GetIdentityAsync();
                if (!string.IsNullOrWhiteSpace(passHashed))
                {
                    if (BCrypt.Net.BCrypt.CheckPassword(curPasswordEntry.Text, passHashed))
                    {
                        Debug.WriteLine("Current password match");

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
                    }
                    else {
                        messageLabel.Text = "Current Password(s) is wrong.";
                    }
                }
            } else {
                messageLabel.Text = "No new Password(s) entered or entered Passwords differ.";
            }
        }

        bool AreDetailsValid()
        {
            return (
                    !string.IsNullOrWhiteSpace(vm.CurrentUser.Username) && 
                    !string.IsNullOrWhiteSpace(vm.CurrentUser.Password) && 
                    !string.IsNullOrWhiteSpace(vm.CurrentUser.Email) && 
                    vm.CurrentUser.Email.Contains("@") &&
                    !string.IsNullOrWhiteSpace(newPassword1Entry.Text) &&
                    !string.IsNullOrWhiteSpace(newPassword2Entry.Text) &&
                    newPassword1Entry.Text == newPassword2Entry.Text
                   );
        }
    }
}
