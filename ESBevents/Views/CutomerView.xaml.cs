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
					// Dan met de velden de webservice aanroepen.

					//var webSrvc = new GetEventLogWS();
					//var status = await webSrvc.GetEventLogAsync(vm);

					//if (status == HttpStatusCode.Continue)
					//{
					//  // De json die terug komt in vm zetten van door het object door te geven.

					//  await Navigation.PushAsync(new EventlogView(vm));
					//}


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
