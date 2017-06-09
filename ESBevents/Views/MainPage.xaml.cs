using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using ESBevents.Abstractions;
using ESBevents.ViewModels;
using ESBevents.WebServices;
using Xamarin.Forms;

namespace ESBevents.Views
{
    public partial class MainPage : ContentPage
    {
        internal MainPageViewModel vm = new MainPageViewModel();

        public static string BaseURL = "";

        public MainPage()
        {
            InitializeComponent();

            BindingContext = vm;

            customerList.ItemTapped += (sender, e) =>
            {
                Navigation.PushAsync(new CustomerView(vm.SelectedItem));
                //Navigation.PushAsync(new EventView());

                ((ListView)sender).SelectedItem = null;
            };
        }

        public double width { get; set; }
        public double height { get; set; }

        protected override void OnSizeAllocated(double width, double height) {
            base.OnSizeAllocated(width, height);

			if (width != this.width || height != this.height)
			{
				this.width = width;
				this.height = height;
				if (width > height)
				{
                    // landscape
                    Debug.WriteLine("Landscape width: " + width);
                    Debug.WriteLine("Landscape height: " + height);
				}
				else
				{
					// portrait
					Debug.WriteLine("Portrait width: " + width);
					Debug.WriteLine("Portrait height: " + height);
				}
			}

			var orientation = DependencyService.Get<IDeviceOrientation>().GetOrientation();
			Debug.WriteLine("Orientation: " + orientation);
		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView());
		}
	}
}
