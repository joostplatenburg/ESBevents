using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace ESBevents
{
	public partial class OptionView : ContentPage
	{
		public OptionView()
		{
			InitializeComponent();

			SetTextValue("ipALLO", ipALLO);
			SetTextValue("ipALLT", ipALLT);
			SetTextValue("ipALLA", ipALLA);
			SetTextValue("ipALLP", ipALLP);

			SetTextValue("ipDBZO", ipDBZO);
			SetTextValue("ipDBZT", ipDBZT);
			SetTextValue("ipDBZA", ipDBZA);
			SetTextValue("ipDBZP", ipDBZP);

			SetTextValue("ipSHLO", ipSHLO);
			SetTextValue("ipSHLT", ipSHLT);
			SetTextValue("ipSHLA", ipSHLA);
			SetTextValue("ipSHLP", ipSHLP);

			SetTextValue("ipSPZO", ipSPZO);
			SetTextValue("ipSPZT", ipSPZT);
			SetTextValue("ipSPZA", ipSPZA);
			SetTextValue("ipSPZP", ipSPZP);

			SetTextValue("ipZGBO", ipZGBO);
			SetTextValue("ipZGBT", ipZGBT);
			SetTextValue("ipZGBA", ipZGBA);
			SetTextValue("ipZGBP", ipZGBP);

			SetTextValue("portEventsALL", portEventsALL);
			SetTextValue("portProcessALL", portProcessALL);
			SetTextValue("portEventsDBZ", portEventsDBZ);
			SetTextValue("portProcessDBZ", portProcessDBZ);
			SetTextValue("portEventsSHL", portEventsSHL);
			SetTextValue("portProcessSHL", portProcessSHL);
			SetTextValue("portEventsSPZ", portEventsSPZ);
			SetTextValue("portProcessSPZ", portProcessSPZ);
			SetTextValue("portEventsZGB", portEventsZGB);
			SetTextValue("portProcessZGB", portProcessZGB);
		}

		void SaveOptions(object sender, EventArgs e)
		{
			var ik = sender as Button;

			SaveTextValue("ipALLO", ipALLO);
			SaveTextValue("ipALLT", ipALLT);
			SaveTextValue("ipALLA", ipALLA);
			SaveTextValue("ipALLP", ipALLP);

			SaveTextValue("ipDBZO", ipDBZO);
			SaveTextValue("ipDBZT", ipDBZT);
			SaveTextValue("ipDBZA", ipDBZA);
			SaveTextValue("ipDBZP", ipDBZP);

			SaveTextValue("ipSHLO", ipSHLO);
			SaveTextValue("ipSHLT", ipSHLT);
			SaveTextValue("ipSHLA", ipSHLA);
			SaveTextValue("ipSHLP", ipSHLP);

			SaveTextValue("ipSPZO", ipSPZO);
			SaveTextValue("ipSPZT", ipSPZT);
			SaveTextValue("ipSPZA", ipSPZA);
			SaveTextValue("ipSPZP", ipSPZP);

			SaveTextValue("ipZGBO", ipZGBO);
			SaveTextValue("ipZGBT", ipZGBT);
			SaveTextValue("ipZGBA", ipZGBA);
			SaveTextValue("ipZGBP", ipZGBP);

            SaveTextValue("portEventsALL", portEventsALL);
            SaveTextValue("portProcessALL", portProcessALL);
			SaveTextValue("portEventsDBZ", portEventsDBZ);
			SaveTextValue("portProcessDBZ", portProcessDBZ);
			SaveTextValue("portEventsSHL", portEventsSHL);
			SaveTextValue("portProcessSHL", portProcessSHL);
			SaveTextValue("portEventsSPZ", portEventsSPZ);
			SaveTextValue("portProcessSPZ", portProcessSPZ);
			SaveTextValue("portEventsZGB", portEventsZGB);
			SaveTextValue("portProcessZGB", portProcessZGB);

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
