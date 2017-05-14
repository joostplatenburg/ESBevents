using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;

namespace ESBevents.ViewModels
{
	public class CustomerViewModel : INotifyPropertyChanged
	{
		public CustomerViewModel()
		{
			_customer = new CustomerModel();
			Initialize();
		}

		public CustomerViewModel(CustomerModel _cm)
		{
			_customer = _cm;
            Initialize();
		}
        internal void Initialize()
        {
			_actions = new List<ActionModel>();

			Actions.Add(new ActionModel { ID = 1, Name = "Show the eventlog Ontwikkel omgeving", Logo = "EventLog.png" });
			Actions.Add(new ActionModel { ID = 2, Name = "Show the eventlog Test omgeving", Logo = "EventLog.png" });
			Actions.Add(new ActionModel { ID = 3, Name = "Show the eventlog Acceptatie omgeving", Logo = "EventLog.png" });
            Actions.Add(new ActionModel { ID = 4, Name = "Show the eventlog Productie omgeving", Logo = "EventLog.png" });
			var ProcessStart = new ActionModel { ID = 5, Name = "Start Business Process", Logo = "ProcessStart.png" }; Actions.Add(ProcessStart);

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
		private CustomerModel _customer;
		public CustomerModel Customer
		{
			get { return _customer; }
			set
			{
				if (_customer == value) return;

				_customer = value;

				OnPropertyChanged("Customer");
			}
		}

        public string Name { get { return Customer.Name; } }
		public string IPNumberO { get { return Customer.IPNumberO; } }
		public string IPNumberT { get { return Customer.IPNumberT; } }
		public string IPNumberA { get { return Customer.IPNumberA; } }
		public string IPNumberP { get { return Customer.IPNumberP; } }
		public string PortNumberEL { get { return Customer.PortNumberEL; }} // Eventlog
        public string PortNumberSP { get { return Customer.PortNumberSP; } } // StartProcess
        public string Logo { get {return Customer.Logo; } }

		private List<ActionModel> _actions;
		public List<ActionModel> Actions
		{
			get { return _actions; }
			set
			{
				if (_actions == value)
					return;

				_actions = value;

				OnPropertyChanged("Actions");
			}
		}

		private ActionModel _selectedActionItem;
		public ActionModel SelectedActionItem
		{
			get { return _selectedActionItem; }
			set
			{
				if (_selectedActionItem == value)
					return;

				_selectedActionItem = value;

				OnPropertyChanged("SelectedActionItem");
			}
		}

		private List<EventModel> _eventlog;
		public List<EventModel> Eventlog
		{
            get {
                //_eventlog.Sort((a, b) => a.CompareTo(b));

                return _eventlog; 
            }
			set
			{
				if (_eventlog == value)
					return;

				_eventlog = value;

				OnPropertyChanged("Eventlog");
			}
		}

		private EventModel _event;
		public EventModel Event
		{
			get { return _event; }
			set
			{
				if (_event == value)
					return;

				_event = value;

				OnPropertyChanged("Event");
			}
		}
		#endregion Properties
	}
}
