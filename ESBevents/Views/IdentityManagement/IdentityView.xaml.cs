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
            var retval = vm.ApproveIdentity();

            if (retval.Result)
            {
                await DisplayAlert("Approve Identity", "Identity is Approved", "OK");
            }
        }
	}
}
