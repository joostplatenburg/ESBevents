using System;
using ESBevents.Models;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents
{
    public partial class DeliverylogView : ContentPage
	{
        internal PubSubLogViewModel vm;

        public DeliverylogView()
		{
			InitializeComponent();

            vm = new PubSubLogViewModel();

			Initialize();
		}

       public DeliverylogView(CustomerViewModel _cVM)
		{
			InitializeComponent();

            vm = new PubSubLogViewModel(_cVM);

			Initialize();
		}


        public DeliverylogView(PubSubLogViewModel _psVM)
        {
            InitializeComponent();

            vm = _psVM;

            Initialize();
        }

		void Initialize()
		{
			BindingContext = vm;

			deliveryList.ItemTapped += (sender, e) =>
			{
				//Navigation.PushAsync(new EventView(vm.SelectedItem));
				////Navigation.PushAsync(new EventView());

				//((ListView)sender).SelectedItem = null;
			};
		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView());
		}

	}
}
