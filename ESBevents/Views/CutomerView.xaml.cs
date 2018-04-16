using System;
using System.Collections.Generic;
using System.Net;
using ESBevents.Models;
using ESBevents.ViewModels;
using ESBevents.WebServices;
using Xamarin.Forms;

namespace ESBevents
{
	public partial class CustomerView : ContentPage
	{
		private CustomerViewModel vm = new CustomerViewModel();

		public CustomerView()
		{
			InitializeComponent();
		
            Initialize();
		}

		public CustomerView(MainPageViewModel mpvm)
		{
			InitializeComponent();

            vm = new CustomerViewModel();
            vm.Customer = mpvm.Customer;
            vm.Customers = mpvm.Customers;
			
            Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;
		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView(vm.Customers));
		}

		async void ToonEventLog(object sender, EventArgs e)
		{
			var but = sender as Button;
			vm.Environment = but.Text;

			// Dan met de velden de webservice aanroepen.
			var webSrvc = new GetEventLogWS();
			var status = await webSrvc.GetEventLogAsync(vm);

			if (status == HttpStatusCode.Continue)
			{
			  // De json die terug komt in vm zetten van door het object door te geven.
			  await Navigation.PushAsync(new EventlogView(vm));
			}

			//((ListView)sender).SelectedItem = null;
		}

		async void  StartProcess(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ProcessStartView(vm));

			//((ListView)sender).SelectedItem = null;
        }

        async void ToonPubsubKoppelingen(object sender, EventArgs e)
        {
            var but = sender as Button;
            vm.Environment = but.Text;

            await Navigation.PushAsync(new DeliveryStatusView(vm));

            //((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
	}
}
