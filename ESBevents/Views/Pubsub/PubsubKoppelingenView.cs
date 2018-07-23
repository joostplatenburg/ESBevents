using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using ESBevents.Models;
using ESBevents.ViewModels;
using ESBevents.Services;
using Xamarin.Forms;

namespace ESBevents
{
    public partial class PubsubKoppelingenView : ContentPage
	{
        internal PubsubKoppelingenViewModel vm;

        public PubsubKoppelingenView()
		{
			InitializeComponent();

            vm = new PubsubKoppelingenViewModel();

			Initialize();
		}

        public PubsubKoppelingenView(DeliveryStatusViewModel dsvm)
		{
			InitializeComponent();

            vm = new PubsubKoppelingenViewModel();
            vm.Customer = dsvm.Customer;
            vm.Customers = dsvm.Customers;
            vm.Environment = dsvm.Environment;
            vm.Status = dsvm.Status;

            foreach(KoppelingModel km in dsvm.Customer.Koppelingen) {
                vm.Koppelingen.Add(km);

                if (km.IsSubscriber){
                    vm.Subscribers.Add(km);
                } else {
                    vm.Publishers.Add(km);
                }
            }

			Initialize();
		}

        public PubsubKoppelingenView(CustomerModel _customer)
        {
            InitializeComponent();

            // Hier bij het starten van de pubsub view
            vm = new PubsubKoppelingenViewModel(_customer);

			Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;

			koppelingenList.ItemTapped += async (sender, e) =>
			{
                var selected = ((ListView)sender).SelectedItem as KoppelingModel;

                vm.SelectedKoppeling = selected;
                vm.Koppeling = selected.Name;

				Debug.WriteLine("Start: " + selected.Name);

                if (vm != null)
                {
                    //await Navigation.PushAsync(new DeliveryStatusView(vm));
                    // Dan met de velden de webservice aanroepen.
                    var webSrvc = new EnsemblePSServices(vm);
                    var status = await webSrvc.GetDeliverylogAsync();

                    if (status == HttpStatusCode.Continue)
                    {
                        // De json die terug komt in vm zetten van door het object door te geven.
                        await Navigation.PushAsync(new DeliverylogView(vm));
                    }
               }

                ((ListView)sender).SelectedItem = null;
			};
		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView(vm.Customers));
		}

	}
}
