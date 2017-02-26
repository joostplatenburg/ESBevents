using System;
using System.Collections.Generic;
using System.Net;
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

			// Fetch basURL from persistent storage
			if (Application.Current.Properties.ContainsKey("baseURL"))
			{
				var _baseURL = Application.Current.Properties["baseURL"] as string;
				BaseURL = _baseURL;
			}
			else
			{
				BaseURL = "http://52.73.112.29:54322/DXCUtilities/";
			}
		}

		void OnClick(object sender, EventArgs e)
		{
			//Navigation.PushAsync(new OptionsPage());
		}

		async void ToonEvents (object sender, EventArgs e)
		{
			var ik = sender as Button;

			// Dan met de velden de webservice aanroepen.
			var webSrvc = new GetEventLogWS();
			var status = await webSrvc.GetEventLogAsync(vm);

			if (status == HttpStatusCode.Continue)
			{
				// De json die terug komt in vm zetten van door het object door te geven.

   				await Navigation.PushAsync(new EventlogView(vm));
			}
		}
	}
}
