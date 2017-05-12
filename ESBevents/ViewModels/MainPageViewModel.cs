using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;

namespace ESBevents.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
			_customers = new List<CustomerModel>();

			var ALL = new CustomerModel { Name = "Alliade", IPNumber = "123.456.789.012", PortNumber = "54321" }; Customers.Add(ALL);
			var SPZ = new CustomerModel { Name = "Philadelphia", IPNumber = "123.456.789.012", PortNumber = "54322" }; Customers.Add(SPZ);
			var DBZ = new CustomerModel { Name = "Dichterbij", IPNumber = "123.456.789.012", PortNumber = "54323" }; Customers.Add(DBZ);
			var SHL = new CustomerModel { Name = "'s Heeren Loo", IPNumber = "123.456.789.012", PortNumber = "54324" }; Customers.Add(SHL);
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
		private List<CustomerModel> _customers;
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

		private CustomerModel _customer;
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

		private string _mainMessage;
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

		private Boolean _progressvisible;
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
		#endregion Properties
	}
}
