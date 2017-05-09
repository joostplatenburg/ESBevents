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
<<<<<<< HEAD
				//Navigation.PushAsync(new EventView(vm.SelectedItem.Event));
				Navigation.PushAsync(new EventView(vm));
=======
				Navigation.PushAsync(new EventView(vm.SelectedItem));
				//Navigation.PushAsync(new EventView());
>>>>>>> 0a1a82a... * ESBevents.Droid.csproj: Voor de save button in de optionview

				((ListView)sender).SelectedItem = null;
			};
		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView());
		}

	}
}
