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
using ESBevents.Services;
using Xamarin.Forms;

namespace ESBevents.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            var rc = GetCustomers();
        }

        private async Task<bool> GetCustomers()
        {
            var rc = await GetCustomersAsync();

            return true;
        }

        async Task<bool> GetCustomersAsync()
        {
            var webSrvc = new PubsubServices();
            var status = await webSrvc.GetCustomersAsync(this);

            if (status != HttpStatusCode.Continue)
            {
                // WAT TE DOEN ALS ER EEN FOUT OPTREED
                Debug.WriteLine("DXCPS - Fout bij ophalen customer data");

                return false;
            }

            return true;
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
                OnPropertyChanged("Customer");
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

        #endregion Properties

        #region Commands

        #endregion Commands
    }
}
