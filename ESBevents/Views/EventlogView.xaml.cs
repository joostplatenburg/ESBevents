using System;
using System.Collections.Generic;
using ESBevents.Models;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents
{
    public partial class EventlogView : ContentPage
	{
		internal EventlogViewModel vm;

		public EventlogView()
		{
			InitializeComponent();

			vm = new EventlogViewModel();

			Initialize();
		}

		public EventlogView(MainPageViewModel _mpVM)
		{
			InitializeComponent();

			vm = new EventlogViewModel();
			//vm.Zorgverleners = _mpVM.Zorgverleners;

			Initialize();
		}

		public EventlogView(CustomerViewModel cvm)
		{
			InitializeComponent();

			vm = new EventlogViewModel(cvm);
            vm.Customer = cvm.Customer;
            vm.Customers = cvm.Customers;
            vm.Environment = cvm.Environment;
            vm.Logo = cvm.Customer.Logo;

			Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;

			eventList.ItemTapped += (sender, e) =>
			{
				Navigation.PushAsync(new EventView(vm));
				//Navigation.PushAsync(new EventView());

				((ListView)sender).SelectedItem = null;
			};
		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView(vm.Customers));
		}

	}
}
