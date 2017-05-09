using System;
using System.Collections.Generic;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents
{
	public partial class EventView : ContentPage
	{
		internal EventViewModel vm;

		public EventView()
		{
			InitializeComponent();
<<<<<<< HEAD

			vm = new EventViewModel();

			Initialize();
		}

		public EventView(EventlogViewModel _elVM)
		{
			InitializeComponent();

			vm = new EventViewModel(_elVM);

=======
			vm = new EventViewModel();
			Initialize();
		}

		public EventView(EventViewModel _vm)
		{
			InitializeComponent();

			vm = _vm;
>>>>>>> 0a1a82a... * ESBevents.Droid.csproj: Voor de save button in de optionview
			Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;
<<<<<<< HEAD
=======

		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView());
>>>>>>> 0a1a82a... * ESBevents.Droid.csproj: Voor de save button in de optionview
		}
	}
}
