using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using ESBevents.Models;
using ESBevents.ViewModels;
using ESBevents.WebServices;
using Xamarin.Forms;

namespace ESBevents
{
    public partial class DeliveryView : ContentPage
	{
        internal DeliveryViewModel vm;

        public DeliveryView()
		{
			InitializeComponent();
            vm = new DeliveryViewModel();
			Initialize();
		}

        public DeliveryView(DeliverylogViewModel _vm)
		{
			InitializeComponent();

            vm = new DeliveryViewModel(_vm);
            vm.Environment = _vm.Environment;
            vm.Delivery = _vm.SelectedDelivery;
            vm.Logo = _vm.Logo;
            vm.Customer = _vm.Customer;
            vm.Customers = _vm.Customers;

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

        async void ResendMessage(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Resend Message", "Are you sure you want to resend the message?", "Yes", "No");
            if(answer)
            {
                Debug.WriteLine("Resend Message");

                var httpstatus = await ResendMessage();
                if (httpstatus == HttpStatusCode.Continue) {
                    await Navigation.PopAsync();
                }
            } 
        }

        async Task<HttpStatusCode> ResendMessage()
        {
            // Dan met de velden de webservice aanroepen.
            var pubsubServicesClient = new PubsubServices();
            var httpstatus = await pubsubServicesClient.ResendMessageAsync(vm);

            return httpstatus;
        }

        async void ObsoleteMessage(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Status Change", "Are you sure you want to set the deliverystatus to Obsolete?", "Yes", "No");
            if(answer)
            {
                Debug.WriteLine("Make Messagestatus Obsolete");
            } 
        }

        async void ResetMessage(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Reset Counter", "Are you sure yoou want to reset the retry counter?", "Yes", "No");
            if(answer)
            {
                Debug.WriteLine("Reset Retry Counter on Message");
            } 
        }
	}
}
