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

			vm = new EventViewModel();

			Initialize();
		}

		public EventView(EventlogViewModel _elVM)
		{
			InitializeComponent();

			vm = new EventViewModel(_elVM);

			Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;
		}
	}
}
