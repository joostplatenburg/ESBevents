using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;

namespace ESBevents.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
			_eventlog = new List<EventModel>();
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
		private List<EventModel> _eventlog;
		public List<EventModel> EventLog
		{
			get { return _eventlog; }
			set
			{
				if (_eventlog == value)
					return;

				_eventlog = value;

				OnPropertyChanged("EventLog");
			}
		}

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

		private string _httpport;
		public string HttpPort
		{
			get { return _httpport; }
			set
			{
				if (_httpport == value) return;

				_httpport = value;

				OnPropertyChanged("HttpPort");
			}
		}

		private string _httpserver;
		public string HttpServer
		{
			get { return _httpserver; }
			set
			{
				if (_httpserver == value) return;

				_httpserver = value;

				OnPropertyChanged("HttpServer");
			}
		}
		private string _mainMessage;
		public string MainMessage
		{
			get { return _mainMessage; }
			set
			{
				if (_mainMessage == value) return;

				_mainMessage = value;

				OnPropertyChanged("MainMessage");
			}
		}

		private Boolean _progressvisible;
		public Boolean ProgressVisible
		{
			get { return _progressvisible; }
			set
			{
				if (_progressvisible == value) return;

				_progressvisible = value;

				OnPropertyChanged("ProgressVisible");
			}
		}
		#endregion Properties
	}
}
