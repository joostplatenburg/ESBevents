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
    
            var ALL = new CustomerModel { Name = "Alliade Zorggroep", Logo="ALL.png", IPO = "192.168.2.14", IPT = "2.73.112.29", IPA = "", IPP="", PortEnsemble="54321", PortPubsub="54331", StartBP=false, ToonEventlog=false, ToonPSlog=false};
            Customers.Add(ALL);

            var DBZ = new CustomerModel { Name = "Dichterbij", Logo = "DBZ.png", IPO = "192.168.2.14", IPT = "52.73.112.29", IPA = "10.100.80.104", IPP = "10.100.80.73", PortEnsemble = "54322", PortPubsub = "54332", StartBP = false,ToonEventlog = false, ToonPSlog = false};
            DBZ.Koppelingen = new List<KoppelingModel>();
			var dbz009 = new KoppelingModel { ID = 009, Name = "DBZ009", Description = "AFAS naar UMRA" }; DBZ.Koppelingen.Add(dbz009);
			var dbz010 = new KoppelingModel { ID = 010, Name = "DBZ010", Description = "AFAS naar " }; DBZ.Koppelingen.Add(dbz010);
			var dbz011 = new KoppelingModel { ID = 011, Name = "DBZ011", Description = "AFAS naar " }; DBZ.Koppelingen.Add(dbz011);
			var dbz012 = new KoppelingModel { ID = 012, Name = "DBZ012", Description = "AFAS naar " }; DBZ.Koppelingen.Add(dbz012);
			var dbz014 = new KoppelingModel { ID = 014, Name = "DBZ014", Description = "AFAS naar " }; DBZ.Koppelingen.Add(dbz014);
			var dbz015 = new KoppelingModel { ID = 015, Name = "DBZ015", Description = "AFAS naar " }; DBZ.Koppelingen.Add(dbz015);
			Customers.Add(DBZ);

            var SPZ = new CustomerModel { Name = "Stichting Philadelphia Zorg", Logo="SPZ.png", IPO = "192.168.2.14", IPT = "52.73.112.29", IPA="", IPP="", PortEnsemble = "54323", PortPubsub = "54333", StartBP = false, ToonEventlog = false, ToonPSlog = false };
			SPZ.Koppelingen = new List<KoppelingModel>();
			var spz150 = new KoppelingModel { ID = 150, Name = "SPZ150", Description = "ESB-CMS Medewerkergegevens"}; SPZ.Koppelingen.Add(spz150);
			var spz151 = new KoppelingModel { ID = 151, Name = "SPZ151", Description = "(Her)In- en Doorstroom Accounts"}; SPZ.Koppelingen.Add(spz151);
			var spz152 = new KoppelingModel { ID = 152, Name = "SPZ152", Description = "BO4 naar WACHTRIJ" }; SPZ.Koppelingen.Add(spz152);
			var spz153 = new KoppelingModel { ID = 153, Name = "SPZ153", Description = "ECD P&R Ambulant Clientgegevens"}; SPZ.Koppelingen.Add(spz153);
            Customers.Add(SPZ);

            var SHL = new CustomerModel { Name = "'s Heeren Loo", IPO = "192.168.2.14", IPT = "52.73.112.29", IPA = "", IPP = "", PortEnsemble = "54324", PortPubsub = "54334", Logo = "SHL.png", StartBP = false, ToonEventlog = false, ToonPSlog = false };
			Customers.Add(SHL);

            var ZGB = new CustomerModel { Name = "de Zorgboog", IPO = "192.168.2.14", IPT = "52.73.112.29", IPA = "", IPP = "", PortEnsemble = "54325", PortPubsub = "54335", Logo = "ZGB.png", StartBP = false, ToonEventlog = false, ToonPSlog = false };
            Customers.Add(ZGB);
    
            var DZG = new CustomerModel { Name = "de Zorggroep", IPO = "192.168.2.14", IPT = "52.73.112.29", IPA = "192.168.213.111", IPP = "192.168.213.11", PortEnsemble = "54326", PortPubsub = "54336", Logo = "DZG.png", StartBP = false, ToonEventlog = false, ToonPSlog = false};
            DZG.Koppelingen = new List<KoppelingModel>();
            var DZG001 = new KoppelingModel { ID = 001, Name = "DZG001", Description = "Publisher - AFAS - PUBSUB Medewerkers" }; DZG.Koppelingen.Add(DZG001);
            var DZG002 = new KoppelingModel { ID = 002, Name = "DZG002", Description = "Publisher - AFAS - PUBSUB " }; DZG.Koppelingen.Add(DZG002);
            var DZG003 = new KoppelingModel { ID = 003, Name = "DZG003", Description = "Publisher - TBLOX - PUBSUB Inkoopfacturen" }; DZG.Koppelingen.Add(DZG003);
            var DZG004 = new KoppelingModel { ID = 004, Name = "DZG004", Description = "Publisher - AFAS - PUBSUB" }; DZG.Koppelingen.Add(DZG004);
            var DZG005 = new KoppelingModel { ID = 005, Name = "DZG005", Description = "Publisher - N@tSchool - PUBSUB Studieresultaten" }; DZG.Koppelingen.Add(DZG005);
            var DZG006 = new KoppelingModel { ID = 006, Name = "DZG006", Description = "Publisher - AFAS - PUBSUB" }; DZG.Koppelingen.Add(DZG006);
            var DZG007 = new KoppelingModel { ID = 007, Name = "DZG007", Description = "Subscriber - PUBSUB - HRMAD Medewerkers" }; DZG.Koppelingen.Add(DZG007);
            var DZG008 = new KoppelingModel { ID = 008, Name = "DZG008", Description = "Publisher - AFAS - PUBSUB Kostenplaatsen" }; DZG.Koppelingen.Add(DZG008);
            var DZG009 = new KoppelingModel { ID = 009, Name = "DZG009", Description = "Publisher - AFAS - PUBSUB " }; DZG.Koppelingen.Add(DZG009);
            var DZG010 = new KoppelingModel { ID = 010, Name = "DZG010", Description = "Subscriber - PUBSUB - ONS Medewerkers" }; DZG.Koppelingen.Add(DZG010);
            var DZG011 = new KoppelingModel { ID = 011, Name = "DZG011", Description = "Subscriber - PUBSUB - " }; DZG.Koppelingen.Add(DZG011);
            var DZG012 = new KoppelingModel { ID = 012, Name = "DZG012", Description = "Subscriber - PUBSUB - " }; DZG.Koppelingen.Add(DZG012);
            var DZG013 = new KoppelingModel { ID = 013, Name = "DZG013", Description = "Subscriber - PUBSUB - AFAS Inkoopfacturen" }; DZG.Koppelingen.Add(DZG013);
            var DZG014 = new KoppelingModel { ID = 014, Name = "DZG014", Description = "Subscriber - PUBSUB - CardsOnline Medewerkers" }; DZG.Koppelingen.Add(DZG014);
            var DZG015 = new KoppelingModel { ID = 015, Name = "DZG015", Description = "Subscriber - PUBSUB - N@tSchool Medewerkers" }; DZG.Koppelingen.Add(DZG015);
            var DZG016 = new KoppelingModel { ID = 016, Name = "DZG016", Description = "Subscriber - PUBSUB - AFAS Studieresultaten" }; DZG.Koppelingen.Add(DZG016);
            var DZG017 = new KoppelingModel { ID = 017, Name = "DZG017", Description = "Publisher - AFAS naar PUBSUB Functies" }; DZG.Koppelingen.Add(DZG017);
            var DZG018 = new KoppelingModel { ID = 018, Name = "DZG018", Description = "Subscriber - PUBSUB - HRMAD Functies" }; DZG.Koppelingen.Add(DZG018);
            Customers.Add(DZG);

            var DOB = new CustomerModel { Name = "de Opbouw", IPO = "192.168.2.14", IPT = "52.73.112.29", IPA = "", IPP = "", PortEnsemble = "54327", PortPubsub = "54337", Logo = "DOB.png", StartBP = false, ToonEventlog = false, ToonPSlog = false };
            Customers.Add(DOB);
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
	}
}
