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

			var ALL = new CustomerModel { Name = "Alliade Zorggroep", IPNumber = "123.456.789.012", PortNumberEL = "54321", Logo="ALL.png" }; 
            Customers.Add(ALL);

			var SPZ = new CustomerModel { Name = "Stichting Philadelphia Zorg", IPNumber = "123.456.789.012", PortNumberEL = "54322", Logo = "SPZ.png" }; 
			SPZ.Koppelingen = new List<KoppelingModel>();
			var spz150 = new KoppelingModel { ID = 150, Name = "SPZ150", Description = "ESB-CMS Medewerkergegevens" }; SPZ.Koppelingen.Add(spz150);
			var spz151 = new KoppelingModel { ID = 151, Name = "SPZ151", Description = "(Her)In- en Doorstroom Accounts" }; SPZ.Koppelingen.Add(spz151);
			var spz152 = new KoppelingModel { ID = 152, Name = "SPZ152", Description = "BO4 naar WACHTRIJ" }; SPZ.Koppelingen.Add(spz152);
			var spz153 = new KoppelingModel { ID = 153, Name = "SPZ153", Description = "ECD P&R Ambulant Clientgegevens" }; SPZ.Koppelingen.Add(spz153);
            Customers.Add(SPZ);

			var DBZ = new CustomerModel { Name = "Dichterbij", IPNumber = "123.456.789.012", PortNumberEL = "54323", Logo = "DBZ.png" };
            DBZ.Koppelingen = new List<KoppelingModel>();
			var dbz009 = new KoppelingModel { ID = 009, Name = "DBZ009", Description = "AFAS naar UMRA" }; DBZ.Koppelingen.Add(dbz009);
			var dbz010 = new KoppelingModel { ID = 010, Name = "DBZ010", Description = "AFAS naar " }; DBZ.Koppelingen.Add(dbz010);
			var dbz011 = new KoppelingModel { ID = 011, Name = "DBZ011", Description = "AFAS naar " }; DBZ.Koppelingen.Add(dbz011);
			var dbz012 = new KoppelingModel { ID = 012, Name = "DBZ012", Description = "AFAS naar " }; DBZ.Koppelingen.Add(dbz012);
			var dbz014 = new KoppelingModel { ID = 014, Name = "DBZ014", Description = "AFAS naar " }; DBZ.Koppelingen.Add(dbz014);
			var dbz015 = new KoppelingModel { ID = 015, Name = "DBZ015", Description = "AFAS naar " }; DBZ.Koppelingen.Add(dbz015);
			Customers.Add(DBZ);

			var SHL = new CustomerModel { Name = "'s Heeren Loo", IPNumber = "123.456.789.012", PortNumberEL = "54324", Logo = "SHL.png" }; 
            Customers.Add(SHL);

			var ZGB = new CustomerModel { Name = "de Zorgboog", IPNumber = "123.456.789.012", PortNumberEL = "54324", Logo = "ZGB.png" }; 
            Customers.Add(ZGB);
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

		private CustomerModel _selectedItem;
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
	}
}
