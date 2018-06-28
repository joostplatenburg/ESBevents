using System;
using System.Collections.Generic;
using System.Diagnostics;
using ESBevents.Models;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents
{
	public partial class OptionView : ContentPage
	{
        OptionViewModel vm = new OptionViewModel();

        public OptionView()
        {
            InitializeComponent();

            BindingContext = vm;
            vm.Logo = "DXCLogo3.png";
        }

        public OptionView(List<CustomerModel> _customers)
		{
			InitializeComponent();

            BindingContext = vm;
            vm.Logo = "DXCLogo3.png";
            vm.Customers = _customers;
		}

		void SaveOptions(object sender, EventArgs e)
		{
            Navigation.PopAsync(true);
		}

        void SetTextValue(string Key, Entry obj) {
			if (Application.Current.Properties.ContainsKey(Key))
			{
				obj.Text = Application.Current.Properties[Key] as string;
			}
		}

		void SaveTextValue(string Key, Entry obj)
		{
			if (obj.Text != null)
			{
				Application.Current.Properties[Key] = obj.Text.Replace(",", ".");
                SetTextValue(Key, obj);
			}
		}

        void OnTextChanged(object sender, EventArgs e)
        {
			var obj = sender as Entry;

            obj.Text = obj.Text.Replace(",", ".");
        }
	}
}
