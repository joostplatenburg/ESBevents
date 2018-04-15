using System;
using System.Collections.Generic;
using ESBevents.Models;
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

		public EventView(EventViewModel _vm)
		{
			InitializeComponent();

			vm = _vm;

			Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;

		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView(new List<CustomerModel>()));
		}
	}
}
