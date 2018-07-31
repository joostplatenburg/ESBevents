using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using ESBevents.Services;
using System.Net;

namespace ESBevents.ViewModels
{
    public class ListCustomersViewModel : INotifyPropertyChanged
    {
        public ListCustomersViewModel()
        {
            //_identities = new ObservableCollection<IdentityModel>();
        }

        public ListCustomersViewModel(ActionsViewModel _avm)
        {
            _customers = new ObservableCollection<CustomerModel>();
            _customersall = new ObservableCollection<CustomerModel>();

            GetCustomers();
        }

        private async void GetCustomers()
        {
            // Dan met de velden de webservice aanroepen.
            var webSrvc = new PubsubServices();
            var customers = await webSrvc.GetCustomersAsync();

            foreach(CustomerModel cm in customers)
            {
                Customers.Add(cm);
                CustomersAll.Add(cm);
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
        string _filterValue;
        public string FilterValue
        {
            get { return _filterValue; }
            set
            {
                if (_filterValue == value)
                    return;

                _filterValue = value;

                OnPropertyChanged("Customers");
            }
        }

        ObservableCollection<CustomerModel> _customersall;
        public ObservableCollection<CustomerModel> CustomersAll
        {
            get { return _customersall; }

            set
            {
                if (_customersall == value)
                    return;

                _customersall = value;

                OnPropertyChanged("CustomersAll");
            }
        }

        ObservableCollection<CustomerModel> _customers;
        public ObservableCollection<CustomerModel> Customers
        {
            get
            {
                List<CustomerModel> list = new List<CustomerModel>();

                if (!string.IsNullOrWhiteSpace(FilterValue))
                {
                    if (FilterValue == "Show")
                    {
                        list = _customersall.Where(el => el.ShowInMASList == true).ToList();
                    } else if (FilterValue == "NotShow") {
                        list = _customersall.Where(el => el.ShowInMASList == false).ToList();
                    }

                } else {
                    list = _customersall.ToList();
                }

                _customers.Clear();

                foreach (CustomerModel cm in list)
                {
                    _customers.Add(cm);
                }
                return _customers;
            }

            set
            {
                if (_customers == value)
                    return;

                _customers = value;

                OnPropertyChanged("Customers");
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

        string _logo;
        public string Logo
        {
            get { return _logo; }
            set
            {
                if (_logo == value) return;

                _logo = value;

                OnPropertyChanged("Logo");
            }
        }
        #endregion Properties
    }
}
