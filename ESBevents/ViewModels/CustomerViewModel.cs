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
			_actionsEL = new List<ActionModel>();
			_actionsPS = new List<ActionModel>();

			ActionsEL.Add(new ActionModel { ID = 1, Name = "de Ontwikkel omgeving", Logo = "EventLog.png" });
			ActionsEL.Add(new ActionModel { ID = 2, Name = "de Test omgeving", Logo = "EventLog.png" });
			ActionsEL.Add(new ActionModel { ID = 3, Name = "de Acceptatie omgeving", Logo = "EventLog.png" });
			ActionsEL.Add(new ActionModel { ID = 4, Name = "de Productie omgeving", Logo = "EventLog.png" });
			
            ActionsPS.Add(new ActionModel { ID = 1, Name = "de Ontwikkel omgeving", Logo = "ProcessStart.png" });
			ActionsPS.Add(new ActionModel { ID = 2, Name = "de Test omgeving", Logo = "ProcessStart.png" });
			ActionsPS.Add(new ActionModel { ID = 3, Name = "de Acceptatie omgeving", Logo = "ProcessStart.png" });
			ActionsPS.Add(new ActionModel { ID = 4, Name = "de Productie omgeving", Logo = "ProcessStart.png" });


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

		private List<ActionModel> _actionsEL;
		public List<ActionModel> ActionsEL
		{
			get { return _actionsEL; }
			set
			{
				if (_actionsEL == value)
					return;

				_actionsEL = value;

				OnPropertyChanged("ActionsEL");
			}
		}

		private List<ActionModel> _actionsPS;
		public List<ActionModel> ActionsPS
		{
			get { return _actionsPS; }
			set
			{
				if (_actionsPS == value)
					return;

				_actionsPS = value;

				OnPropertyChanged("ActionsPS");
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

        private string _key;
        public string Key
        {
			get { return _key; }
			set
			{
				if (_key == value)
					return;

				_key = value;

				OnPropertyChanged("Key");
			}
		}
	}
}
