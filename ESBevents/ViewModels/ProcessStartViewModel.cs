using System.ComponentModel;
using System.Collections.ObjectModel;
using ESBevents.Models;

namespace ESBevents.ViewModels
{
    public class ProcessStartViewModel : INotifyPropertyChanged
    {
		public ProcessStartViewModel()
		{
			_koppelingen = new ObservableCollection<KoppelingModel>();
		}

		public ProcessStartViewModel(CustomerViewModel _customerviewmodel)
		{
			_koppelingen = new ObservableCollection<KoppelingModel>();

            foreach(KoppelingModel k in _customerviewmodel.Customer.Koppelingen) {
                Koppelingen.Add(k);
            }
		}

		public ProcessStartViewModel(CustomerModel _customer)
        {
            _koppelingen = new ObservableCollection<KoppelingModel>();

            foreach (KoppelingModel k in _customer.Koppelingen)
            {
                Koppelingen.Add(k);
            }
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
	    private ObservableCollection<KoppelingModel> _koppelingen;

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

		private EventViewModel _selectedKoppelingenItem;
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
	#endregion Properties
    }
}
