using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using ESBevents.ViewModels;
using ESBevents.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ESBevents.Views
{
    public partial class MainPageView : ContentPage
    {
        public MainPageViewModel vm = new MainPageViewModel();

        public MainPageView()
        {
            InitializeComponent();

            BindingContext = vm;

            customerList.ItemTapped += (sender, e) =>
            {
                vm.Customer = vm.SelectedItem;

                Navigation.PushAsync(new ActionsView(vm));

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

                Debug.WriteLine("ScreenWidth: " + App.ScreenWidth);
                Debug.WriteLine("ScreenHeight: " + App.ScreenHeight);

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

			//var orientation = DependencyService.Get<IDeviceOrientation>().GetOrientation();
			//Debug.WriteLine("Orientation: " + orientation);
		}

		public void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView(vm.Customers));
		}
	}
}
