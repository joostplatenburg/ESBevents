using System;
using System.Collections.Generic;
using ESBevents.Models;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents
{
    public partial class DeliverylogView : ContentPage
	{
        internal DeliverylogViewModel vm;

        public DeliverylogView()
		{
			InitializeComponent();

            vm = new DeliverylogViewModel();

			Initialize();
		}

       public DeliverylogView(CustomerViewModel _cVM)
		{
			InitializeComponent();

            vm = new DeliverylogViewModel(_cVM);

			Initialize();
		}


        public DeliverylogView(PubsubKoppelingenViewModel pkvm)
        {
            InitializeComponent();

            vm = new DeliverylogViewModel();

            foreach (DeliveryModel dm in pkvm.Deliveries) {
                vm.Deliveries.Add(dm);
            }

            vm.Customer = pkvm.Customer;
            vm.Customers = pkvm.Customers;
            vm.Environment = pkvm.Environment;
            vm.Status = pkvm.Status;
            vm.Koppeling = pkvm.SelectedKoppeling.Name;

            Initialize();
        }

		void Initialize()
		{
			BindingContext = vm;

			deliveryList.ItemTapped += (sender, e) =>
			{
                var selected = ((ListView)sender).SelectedItem as DeliveryModel;

                vm.SelectedDelivery = selected;

				Navigation.PushAsync(new DeliveryView(vm));

				((ListView)sender).SelectedItem = null;
			};
		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView(vm.Customers));
		}
	}
}
