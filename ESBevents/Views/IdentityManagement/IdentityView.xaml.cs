using System;
using System.Collections.Generic;
using ESBevents.Models;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents.Views.IdentityManagement
{
	public partial class IdentityView : ContentPage
	{
		IdentityViewModel vm;

        public IdentityView()
		{
			InitializeComponent();

			vm = new IdentityViewModel();
			
            Initialize();
		}

        public IdentityView(IdentitiesViewModel idsvm)
		{
			InitializeComponent();

            vm = new IdentityViewModel(idsvm);

			Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;
		}

        async void OnApproveButtonClicked(object sender, EventArgs e)
        {
            var retval = await vm.ApproveIdentity();

            if (retval)
            {
                await DisplayAlert("Approve Identity", "Identity is Approved", "OK");
            }
        }

        async void OnSetCustomerButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Select Customer", "How to select a customer?", "OK");
        }
	}
}
