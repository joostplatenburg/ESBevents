using System.ComponentModel;
using System.Collections.ObjectModel;
using ESBevents.Models;
using System.Collections.Generic;

namespace ESBevents.ViewModels
{
    public class ProcessStartViewModel : INotifyPropertyChanged
    {
		public ProcessStartViewModel()
		{
			_koppelingen = new ObservableCollection<KoppelingModel>();
		}

		public ProcessStartViewModel(ActionsViewModel _avm)
		{
			_koppelingen = new ObservableCollection<KoppelingModel>();

            foreach(KoppelingModel k in _avm.Customer.Koppelingen) {
                Koppelingen.Add(k);
            }

			Customer = _avm.Customer;
		}

		public ProcessStartViewModel(CustomerModel _customer)
        {
            _koppelingen = new ObservableCollection<KoppelingModel>();

            foreach (KoppelingModel k in _customer.Koppelingen)
            {
                Koppelingen.Add(k);
            }

			Customer = _customer;
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
        ObservableCollection<KoppelingModel> _koppelingen;
        public ObservableCollection<KoppelingModel> Koppelingen
		{
			get { return _koppelingen; }
			set {
				if (_koppelingen == value)
					return;

				_koppelingen = value;

				OnPropertyChanged ("Koppelingen");
			}
		}

        EventViewModel _selectedKoppelingenItem;
        public EventViewModel SelectedKoppelingenItem
		{
			get { return _selectedKoppelingenItem; }
			set {
				if (_selectedKoppelingenItem == value) 
					return;
					
				_selectedKoppelingenItem = value;

				OnPropertyChanged("SelectedKoppelingenItem");
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
			get { return _customer;}
			set {
				if (_customer == value) return;

				_customer = value;

				OnPropertyChanged("Customer");
			}
		}

		public string Logo { get { return Customer.Logo; } }

		#endregion Properties
    }
}
