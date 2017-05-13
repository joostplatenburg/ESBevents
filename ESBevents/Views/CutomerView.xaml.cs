using System;
using System.Collections.Generic;
using ESBevents.Models;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents
{
	public partial class CustomerView : ContentPage
	{
		internal CustomerViewModel vm = new CustomerViewModel();

		public CustomerView()
		{
			InitializeComponent();
		
            Initialize();
		}

		public CustomerView(CustomerModel cm)
		{
			InitializeComponent();

			vm.Customer = cm;
			
            Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;

			actionList.ItemTapped += (sender, e) =>
			{
                if (vm.SelectedActionItem.ID == 1) {
                    Navigation.PushAsync(new EventlogView(vm.Customer));
 
                } else if (vm.SelectedActionItem.ID == 2) {
                    Navigation.PushAsync(new ProcessStartView(vm.Customer));
                    
                }

				((ListView)sender).SelectedItem = null;
			};
		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView());
		}
	}
}
