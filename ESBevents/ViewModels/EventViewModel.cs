﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;

namespace ESBevents.ViewModels
{
	public class EventViewModel : INotifyPropertyChanged
	{
		public EventViewModel()
		{

		}

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string name)
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
		#endregion INotifyPropertyChanged implementation

		#region Properties
		private EventModel _event;
		public EventModel Event
		{
			get { return _event; }
			set
			{
				if (_event == value) return;

				_event = value;

				OnPropertyChanged("Event");
			}
		}

		public string TimeLogged { get { return string.Format("{0}", Event.TimeLogged); } }
		public string ConfigName { get { return string.Format("{0}", Event.ConfigName); } }
		public string Text { get { return string.Format("{0}", Event.Text); } }

		public string TypeImage
		{
			get {
				if (Event.Type != null)
				{
					if (Event.Type == "1")
					{
						return "led_blue.png";
					}
					else if (Event.Type == "2")
					{
						return "led_red.png";
					}
					else if (Event.Type == "3")
					{
						return "led_yellow.png";
					}
					else if (Event.Type == "4")
					{
						return "led_green.png";
					}
				}

				return "";
				}
		}
		#endregion Properties
	}
}