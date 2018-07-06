using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;
using ESBevents.WebServices;

namespace ESBevents.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        public CustomerViewModel()
        {
            Customer = new CustomerModel { Logo = "DXC_180.png", ToonPSlog = true, ToonEventlog = true, StartBP = false };

            GetCustomer();
        }

        async void GetCustomer()
        {
            await GetCustomerAsync();
        }

        async Task GetCustomerAsync()
        {
            var webSrvc = new GetCustomerDataWS();
            var status = await webSrvc.GetCustomerAsync(this, App.CurrentUser.CustomerId);

            if (status != HttpStatusCode.Continue)
            {
                // WAT TE DOEN ALS ER EEN FOUT OPTREED
                Debug.WriteLine("DXCPS - Fout bij ophalen customer data");
            }
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
                OnPropertyChanged("Logo");
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

        bool _psCommands = true;
        public bool psCommands
        {
            get { return _psCommands; }
            set
            {
                if (_psCommands == value) return;

                _psCommands = value;

                OnPropertyChanged("psCommands");
            }
        }

        bool _elCommands = true;
        public bool elCommands
        {
            get { return _elCommands; }
            set
            {
                if (_elCommands == value) return;

                _elCommands = value;

                OnPropertyChanged("elCommands");
            }
        }

        bool _sbCommands = true;
        public bool sbCommands
        {
            get { return _sbCommands; }
            set
            {
                if (_sbCommands == value) return;

                _sbCommands = value;

                OnPropertyChanged("sbCommands");
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
