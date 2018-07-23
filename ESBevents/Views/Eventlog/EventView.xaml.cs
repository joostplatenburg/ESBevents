using System;
using System.Collections.Generic;
using ESBevents.Models;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents
{
	public partial class EventView : ContentPage
	{
		EventViewModel vm;

		public EventView()
		{
			InitializeComponent();
			vm = new EventViewModel();
			Initialize();
		}

        public EventView(EventlogViewModel elvm)
		{
			InitializeComponent();

			vm = elvm.SelectedItem;
            vm.Customers = elvm.Customers;
            vm.Logo = elvm.Customer.Logo;

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
	}
}
