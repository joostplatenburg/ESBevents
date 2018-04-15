using System;
using System.Collections.Generic;
using System.Diagnostics;
using ESBevents.Models;
using ESBevents.ViewModels;
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
            vm.Delivery = _vm.SelectedDelivery;
            vm.Logo = _vm.Logo;

			Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;

		}

        void OnClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OptionView(new List<CustomerModel>()));
        }

        void DeleteMessage(object sender, EventArgs e)
        {
            Debug.WriteLine("DeleteMessage");
        }

        void ResendMessage(object sender, EventArgs e)
        {
            Debug.WriteLine("ResendMessage");
        }
	}
}
