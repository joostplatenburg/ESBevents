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

			actionList.ItemTapped += async (sender, e) => 
			{
                if (vm.SelectedActionItem.ID >= 1 && vm.SelectedActionItem.ID <= 4) {
					// Dan met de velden de webservice aanroepen.
					var webSrvc = new GetEventLogWS();
					var status = await webSrvc.GetEventLogAsync(vm);

					if (status == HttpStatusCode.Continue)
					{
					  // De json die terug komt in vm zetten van door het object door te geven.

					  await Navigation.PushAsync(new EventlogView(vm));
					}

				}
				else if (vm.SelectedActionItem.ID == 5)
				{
					await Navigation.PushAsync(new ProcessStartView(vm.Customer));                    
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
