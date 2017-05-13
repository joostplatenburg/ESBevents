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

		void SaveOptions(object sender, EventArgs e)
		{
			var ik = sender as Button;

			Application.Current.Properties["ipALL"] = ipALL.Text;
			Application.Current.Properties["ipALLtst"] = ipALLtst.Text;
			Application.Current.Properties["portEventsALL"] = portEventsALL.Text;
			Application.Current.Properties["portProcessALL"] = portProcessALL.Text;

			Application.Current.Properties["ipDBZ"] = ipDBZ.Text;
			Application.Current.Properties["ipDBZtst"] = ipDBZtst.Text;
			Application.Current.Properties["portEventsDBZ"] = portEventsDBZ.Text;
			Application.Current.Properties["portProcessDBZ"] = portProcessDBZ.Text;

			Application.Current.Properties["ipSPZ"] = ipSPZ.Text;
			Application.Current.Properties["ipSPZtst"] = ipSPZtst.Text;
			Application.Current.Properties["portEventsSPZ"] = portEventsSPZ.Text;
			Application.Current.Properties["portProcessSPZ"] = portProcessSPZ.Text;

			Application.Current.Properties["ipSHL"] = ipSHL.Text;
			Application.Current.Properties["ipSHLtst"] = ipSHLtst.Text;
			Application.Current.Properties["portEventsSHL"] = portEventsSHL.Text;
			Application.Current.Properties["portProcessSHL"] = portProcessSHL.Text;

			Application.Current.Properties["ipZGB"] = ipZGB.Text;
			Application.Current.Properties["ipZGBtst"] = ipZGBtst.Text;
			Application.Current.Properties["portEventsZGB"] = portEventsZGB.Text;
			Application.Current.Properties["portProcessZGB"] = portProcessZGB.Text;

		}
	}
}
