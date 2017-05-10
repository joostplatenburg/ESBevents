using System;
using System.Collections.Generic;
using System.Diagnostics;
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

				Debug.WriteLine("BaseURL uit properties (" + _baseURL + ")");

				BaseURL = _baseURL;
			}
			else
			{
				BaseURL = "http://52.73.112.29:54322/DXCUtilities/";
				BaseURL = "http://192.168.2.23:54322/DXCUtilities/";
			}
		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView());
		}

		async void ToonEvents (object sender, EventArgs e)
		{
			var ik = sender as Button;

			vm.HttpServer = "52.73.112.29";

			if (ik.Text == "Alliade")
			{
				vm.HttpPort = "54320";
			}
			else if (ik.Text == "CoSimCare")
			{
				vm.HttpPort = "54321";
			}
			else if (ik.Text == "Dichterbij")
			{
				vm.HttpPort = "54322";
			} else if (ik.Text == "Philadelphia")
			{
				vm.HttpPort = "54323";
			} else if (ik.Text == "'s Heeren Loo")
			{
				vm.HttpPort = "54324";
			} else if (ik.Text == "Zorgboog")
			{
				vm.HttpPort = "54325";
			}
			vm.MainMessage = "Poortnummer: " + vm.HttpPort;

			try
			{

				// Altijd eerst vorige events verwijderen.
				vm.EventLog.Clear();
				vm.ProgressVisible = true;
				// Dan met de velden de webservice aanroepen.
				var webSrvc = new GetEventLogWS();
				var status = await webSrvc.GetEventLogAsync(vm);

				if (status == HttpStatusCode.Continue)
				{
					vm.ProgressVisible = false;
					// De json die terug komt in vm zetten van door het object door te geven.

					await Navigation.PushAsync(new EventlogView(vm));

					vm.HttpPort = string.Empty;
					vm.MainMessage = string.Empty;
				}
				else
				{
					vm.ProgressVisible = false;

					vm.MainMessage = status.ToString();
				}
			}
			catch (Exception ex)
			{
				vm.ProgressVisible = false;

				vm.MainMessage = ex.Message.ToString();
			}
		}
	}
}
