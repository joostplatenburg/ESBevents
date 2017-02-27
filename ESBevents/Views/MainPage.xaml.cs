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
				BaseURL = "http://{0}:{1}/DXCUtilities/";
			}
		}

		void OnClick(object sender, EventArgs e)
		{
			//Navigation.PushAsync(new OptionsPage());
		}

		async void ToonEvents (object sender, EventArgs e)
		{
			var ik = sender as Button;

			if (ik.Text == "Dichterbij")
			{
				vm.HttpServer = "52.73.112.29";
				vm.HttpPort = "54322";
				vm.MainMessage = "Poortnummer: 54322";
			} else if (ik.Text == "Philadelphia")
			{
				vm.HttpServer = "52.73.112.29";
				vm.HttpPort = "54323";
				vm.MainMessage = "Poortnummer: 54323";
			}

			// Altijd eerst vorige events verwijderen.
			vm.EventLog.Clear();
			vm.IsBusy = true;
			vm.ProgressVisible = true;
			// Dan met de velden de webservice aanroepen.
			var webSrvc = new GetEventLogWS();
			var status = await webSrvc.GetEventLogAsync(vm);

			if (status == HttpStatusCode.Continue)
			{
				vm.IsBusy = false;
				// De json die terug komt in vm zetten van door het object door te geven.

   				await Navigation.PushAsync(new EventlogView(vm));
			}
		}
	}
}
