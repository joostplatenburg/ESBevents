using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;
using ESBevents.WebServices;
using Xamarin.Forms;

namespace ESBevents.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            GetCustomers();
        }

        private async void GetCustomers()
        {
            await GetCustomersAsync();
        }

        private async Task GetCustomersAsync()
        {
            var webSrvc = new GetCustomerDataWS();
            var status = await webSrvc.GetCustomerDataAsync(this);

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
            }
        }

        string _mainMessage;
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

        Boolean _progressvisible;
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

        CustomerModel _selectedItem;
        public CustomerModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem == value)
                    return;

                _selectedItem = value;

                OnPropertyChanged("SelectedItem");
            }
        }


        List<EventModel> _eventlog;
        public List<EventModel> Eventlog
        {
            get { return _eventlog; }
            set
            {
                if (_eventlog == value)
                    return;

                _eventlog = value;

                OnPropertyChanged("Eventlog");
            }
        }
        #endregion Properties

        #region Commands

        //private Command toolbarItemCommand;
        //public Command ToolbarItemCommand
        //{
        //    get
        //    {
        //        return toolbarItemCommand ?? (toolbarItemCommand = new Command(ExecuteToolbarItemCommand));
        //    }
        //}

        //internal void ExecuteToolbarItemCommand()
        //{
        //    Navigation.PushAsync(new OptionView(vm.Customers));
        //}

        #endregion Commands
    }
}
