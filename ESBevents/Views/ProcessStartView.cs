using System;
using System.Diagnostics;
using ESBevents.Models;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents
{
    public partial class ProcessStartView : ContentPage
	{
		internal ProcessStartViewModel vm;

		public ProcessStartView()
		{
			InitializeComponent();

			vm = new ProcessStartViewModel();

			Initialize();
		}

		public ProcessStartView(CustomerViewModel _cVM)
		{
			InitializeComponent();

			vm = new ProcessStartViewModel(_cVM);

			Initialize();
		}

        public ProcessStartView(CustomerModel _customer)
        {
            InitializeComponent();

            vm = new ProcessStartViewModel(_customer);

			Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;

			koppelingenList.ItemTapped += (sender, e) =>
			{
                KoppelingModel selected = ((ListView)sender).SelectedItem as KoppelingModel;

                //// NU DE KOPPELING STARTEN
                /// 
                Debug.WriteLine("Start: " + selected.Name);

				((ListView)sender).SelectedItem = null;
			};
		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView());
		}

	}
}
