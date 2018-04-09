using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
//using ESBevents.Abstractions;
using ESBevents.Models;
using ESBevents.ViewModels;
using ESBevents.WebServices;
using Xamarin.Forms;

namespace ESBevents
{
    public partial class DeliveryStatusView : ContentPage
	{
        internal PubSubLogViewModel vm = new PubSubLogViewModel();

        public DeliveryStatusView()
		{
			InitializeComponent();
		
            Initialize();
		}

        public DeliveryStatusView(PubSubLogViewModel psvm)
		{
			InitializeComponent();

            vm = psvm;
			
            Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;
		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView());
		}

        //void ToonLog(object sender, EventArgs e)
        //{
        //    var but = sender as Button;
        //    Debug.WriteLine("ToonLog: " + but.Text);
        //}

		async void ToonLog(object sender, EventArgs e)
		{
			var but = sender as Button;     
			vm.Status = but.Text;

			// Dan met de velden de webservice aanroepen.
			var webSrvc = new GetPubSubLogWS();
			var status = await webSrvc.GetPubSubLogAsync(vm);

			if (status == HttpStatusCode.Continue)
			{
			  // De json die terug komt in vm zetten van door het object door te geven.
			  await Navigation.PushAsync(new DeliverylogView(vm));
    		}

		//	//((ListView)sender).SelectedItem = null;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

			//MessagingCenter.Subscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId, (message) =>
			//{
			//	//TODO: HandleOrientationChange(message);
			//});
        
        }

	}
}
