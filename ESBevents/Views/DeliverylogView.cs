using System;
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


        public DeliverylogView(PubsubKoppelingenViewModel _psVM)
        {
            InitializeComponent();

            vm = new DeliverylogViewModel();


            foreach (DeliveryModel dm in _psVM.Deliveries) {
                vm.Deliveries.Add(dm);
            }

            vm.Customer = _psVM.Customer;
            vm.Environment = _psVM.Environment;
            vm.Status = _psVM.Status;
            vm.Koppeling = _psVM.Koppeling;

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
