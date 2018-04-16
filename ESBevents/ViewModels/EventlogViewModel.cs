using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;
using System.Collections.ObjectModel;

namespace ESBevents.ViewModels
{
    public class EventlogViewModel : INotifyPropertyChanged
    {
        public EventlogViewModel()
        {
            _eventlog = new ObservableCollection<EventViewModel>();
        }

        public EventlogViewModel(MainPageViewModel _mpVM)
        {
            _eventlog = new ObservableCollection<EventViewModel>();

            foreach (EventModel e in _mpVM.Eventlog)
            {
                if (
                    (!e.SourceClass.StartsWith("Ens.", StringComparison.CurrentCulture)) &&
                    (!e.SourceClass.StartsWith("EnsLib", StringComparison.CurrentCulture)) &&
                    (!e.SourceClass.StartsWith("DXC.", StringComparison.CurrentCulture))
                )
                {
                    _eventlog.Add(new EventViewModel { Event = e });
                }
            }
        }

        public EventlogViewModel(CustomerViewModel _cVM)
        {
            _eventlog = new ObservableCollection<EventViewModel>();

            foreach (EventModel e in _cVM.Eventlog)
            {
                if (
                    (!e.SourceClass.StartsWith("Ens.", StringComparison.CurrentCulture)) &&
                    (!e.SourceClass.StartsWith("EnsLib", StringComparison.CurrentCulture)) &&
                    (!e.SourceClass.StartsWith("DXC.", StringComparison.CurrentCulture))
                )
                {
                    _eventlog.Add(new EventViewModel { Event = e });
                }
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
        ObservableCollection<EventViewModel> _eventlog;

        public ObservableCollection<EventViewModel> Eventlog
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

        EventViewModel _selectedItem;
        public EventViewModel SelectedItem
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
       #endregion Properties
    }
}
