using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ESBevents
{
	public partial class OptionView : ContentPage
	{
		public OptionView()
		{
			InitializeComponent();
		}

		async void SaveOptions(object sender, EventArgs e)
		{
			var ik = sender as Button;

			// Dan met de velden de webservice aanroepen.

			//var webSrvc = new GetEventLogWS();
			//var status = await webSrvc.GetEventLogAsync(vm);

			//if (status == HttpStatusCode.Continue)
			//{
			//	// De json die terug komt in vm zetten van door het object door te geven.

			//	await Navigation.PushAsync(new EventlogView(vm));
			//}
		}
	}
}
