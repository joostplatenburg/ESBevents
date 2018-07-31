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
    public partial class EditCustomerView : ContentPage
    {
        EditCustomerViewModel vm = new EditCustomerViewModel();

        public EditCustomerView()
        {
            InitializeComponent();

            Initialize();
        }

        public EditCustomerView(ListCustomersViewModel _lcvm)
        {
            InitializeComponent();

            vm = new EditCustomerViewModel(_lcvm);

            Initialize();
        }

        private void Initialize()
        {
            BindingContext = vm;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ResetPasswordView(vm));
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ResetPasswordView(vm));
        }
    }
}
