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
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion INotifyPropertyChanged implementation

        #region Properties
        List<CustomerModel> _customers;
        public List<CustomerModel> Customers
        {
            get { return _customers; }
            set
            {
                if (_customers == value)
                    return;

                _customers = value;

                OnPropertyChanged("Customers");
            }
        }

        CustomerModel _customer;
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
        public string IPO { get { return Customer.IPO; } }
        public string IPT { get { return Customer.IPT; } }
        public string IPA { get { return Customer.IPA; } }
        public string IPP { get { return Customer.IPP; } }
        public string PortEnsemble { get { return Customer.PortEnsemble; } } // Eventlog
        public string PortPubsub { get { return Customer.PortPubsub; } } // StartProcess
        public string Logo { get { return Customer.Logo; } }

        public bool ToonEventlog { get { return Customer.ToonEventlog; } }
        public bool StartBP { get { return Customer.StartBP; } }
        public bool ToonPSlog { get { return Customer.ToonPSlog; } }

        ActionModel _selectedActionItem;
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

        List<EventModel> _eventlog;
        public List<EventModel> Eventlog
        {
            get
            {
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

        EventModel _event;
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

        string _environment;
        public string Environment
        {
            get { return _environment; }
            set
            {
                if (_environment == value)
                    return;

                _environment = value;

                OnPropertyChanged("Environment");
            }
        }

        string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                if (_status == value)
                    return;

                _status = value;

                OnPropertyChanged("Status");
            }
        }
    }
}
