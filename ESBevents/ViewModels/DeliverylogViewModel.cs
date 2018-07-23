using System.ComponentModel;
using System.Collections.ObjectModel;
using ESBevents.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Linq;
using Xamarin.Forms;

namespace ESBevents.ViewModels
{
    public class DeliverylogViewModel : INotifyPropertyChanged
    {
        ActionsViewModel avm;
        CustomerModel cm;

        public DeliverylogViewModel()
        {
            _deliveries = new ObservableCollection<DeliveryModel>();
        }

        public DeliverylogViewModel(ActionsViewModel _avm)
        {
            _deliveries = new ObservableCollection<DeliveryModel>();
            avm = _avm;
        }

        public DeliverylogViewModel(CustomerModel _customer)
        {
            _deliveries = new ObservableCollection<DeliveryModel>();
            cm = _customer;
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
        ObservableCollection<DeliveryModel> _deliveries;
        public ObservableCollection<DeliveryModel> Deliveries
        {
            get { return _deliveries; }
            set
            {
                if (_deliveries == value)
                    return;

                _deliveries = value;

                OnPropertyChanged("Deliveries");
            }
        }

        DeliveryModel _selectedDelivery;
        public DeliveryModel SelectedDelivery
        {
            get { return _selectedDelivery; }
            set
            {
                if (_selectedDelivery == value)
                    return;

                _selectedDelivery = value;

                OnPropertyChanged("SelectedDelivery");
            }
        }

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
            }
        }

        public string Logo { get { return Customer.Logo; } }

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

        string _koppeling;
        public string Koppeling
        {
            get { return _koppeling; }
            set
            {
                if (_koppeling == value)
                    return;

                _koppeling = value;

                OnPropertyChanged("Koppeling");
            }
        }
        #endregion Properties
    }
}
