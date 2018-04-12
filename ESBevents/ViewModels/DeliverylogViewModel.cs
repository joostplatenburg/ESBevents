using System.ComponentModel;
using System.Collections.ObjectModel;
using ESBevents.Models;

namespace ESBevents.ViewModels
{
    public class DeliverylogViewModel : INotifyPropertyChanged
    {
        public DeliverylogViewModel()
		{
			_deliveries = new ObservableCollection<DeliveryModel>();
		}

        public DeliverylogViewModel(CustomerViewModel _customerviewmodel)
		{
            _deliveries = new ObservableCollection<DeliveryModel>();
        /*
            foreach(DeliveryModel d in _customerviewmodel.Customer.Koppelingen) {
                Koppelingen.Add(k);
            }

			Customer = _customerviewmodel.Customer;
            Environment = _customerviewmodel.Environment;
            Koppeling = _customerviewmodel.SelectedActionItem;
        */
        }

        public DeliverylogViewModel(CustomerModel _customer)
        {
            _deliveries = new ObservableCollection<DeliveryModel>();
        /*
            foreach (KoppelingModel k in _customer.Koppelingen)
            {
                Koppelingen.Add(k);
            }

			Customer = _customer;
        */
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
	    private ObservableCollection<DeliveryModel> _deliveries;
		public ObservableCollection<DeliveryModel> Deliveries
		{
            get { return _deliveries; }
			set {
                if (_deliveries == value)
					return;

                _deliveries = value;

                OnPropertyChanged ("Deliveries");
			}
		}

        private DeliveryModel _selectedDelivery;
        public DeliveryModel SelectedDelivery
		{
			get { return _selectedDelivery; }
			set {
				if (_selectedDelivery == value) 
					return;
					
				_selectedDelivery = value;

				OnPropertyChanged("SelectedDelivery");
			}
		}

		private CustomerModel _customer;
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

        private string _environment;
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

        private string _status;
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
 
        private string _koppeling;
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
