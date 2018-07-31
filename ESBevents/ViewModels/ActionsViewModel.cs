using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using ESBevents.Models;
using ESBevents.Services;

namespace ESBevents.ViewModels
{
    public class ActionsViewModel : INotifyPropertyChanged
    {
        public ActionsViewModel()
        {
            Debug.WriteLine("DXCPS - ActionsViewModel()");

            var rc = GetCustomerAsync().Result;
        }

        public ActionsViewModel(MainPageViewModel mpvm)
        {
            Debug.WriteLine("DXCPS - ActionsViewModel(MainPageViewModel)");

            Customer = mpvm.Customer;
            Customers = mpvm.Customers;
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
        ObservableCollection<CustomerModel> _customers;
        public ObservableCollection<CustomerModel> Customers
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
        public string IPT { get { return Customer.IPT; } }
        public string IPA { get { return Customer.IPA; } }
        public string IPP { get { return Customer.IPP; } }
        public string PortEnsemble { get { return Customer.PortEnsemble; } }
        public string PortPubsub { get { return Customer.PortPubsub; } }
        public string Logo { get { return Customer.Logo; } }

        public bool? ToonEventlog { get { return Customer.ToonEventlog; } }
        public bool? ToonStartBP { get { return Customer.ToonStartBP; } }
        public bool? ToonPSlog { get { return Customer.ToonPSlog; } }

        public bool ToonIdentities
        {
            get
            {
                if ((App.CurrentUser.Username == "jplatenb") && (Customer.Identifier == "DXC"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

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

        ObservableCollection<EventModel> _eventlog;
        public ObservableCollection<EventModel> Eventlog
        {
            get
            {
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

        bool _sbCommands = false;
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

        bool _idCommands = true;
        public bool idCommands
        {
            get { return _idCommands; }
            set
            {
                if (_idCommands == value) return;

                _idCommands = value;

                OnPropertyChanged("idCommands");
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

        #region Methods
        public async Task<bool> GetCustomerAsync()
        {
            Debug.WriteLine("DXCPS - ActionsViewModel.GetCustomerAsync()");

            var client = new PubsubServices();
            var status = await client.GetCustomerAsync(this, App.CurrentUser.CustomerId);

            if (status != HttpStatusCode.Continue)
            {
                // WAT TE DOEN ALS ER EEN FOUT OPTREED
                Debug.WriteLine("DXCPS - Fout bij ophalen customer data");

                return false;
            }

            Debug.WriteLine("DXCPS - ActionsView.GetCustomerAsync() - Einde");
            return true;
        }
        #endregion Methods
    }
}
