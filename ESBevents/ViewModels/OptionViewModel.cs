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

namespace ESBevents.ViewModels
{
    public class OptionViewModel : INotifyPropertyChanged
    {
        public OptionViewModel()
        {
            Initialize();
        }

        void Initialize()
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

        public string portEnsemble { get { return "54321"; } }
        public string portPubsub { get { return "9924"; } }
        public string IPO { get { return "192.168.2.14"; } }
        public string IPT { get { return "52.73.112.29"; } }
    
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
