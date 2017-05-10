using System;
using System.Collections.Generic;
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

			vm = new EventlogViewModel(_mpVM);
			//vm.Zorgverleners = _mpVM.Zorgverleners;

			Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;

			eventList.ItemTapped += (sender, e) =>
			{
				Navigation.PushAsync(new EventView(vm.SelectedItem));
				//Navigation.PushAsync(new EventView());

				((ListView)sender).SelectedItem = null;
			};
		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView());
		}

	}
}
