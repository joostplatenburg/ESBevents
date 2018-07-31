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
    public class EditCustomerViewModel : INotifyPropertyChanged
    {
        public EditCustomerViewModel()
        {
            //_identities = new ObservableCollection<IdentityModel>();
        }

        public EditCustomerViewModel(ListCustomersViewModel _lcvm)
        {
            Customer = _lcvm.SelectedItem;
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
        CustomerModel _customer;
        public CustomerModel Customer
        {
            get { return _customer; }

            set
            {
                if (_customer == value)
                    return;

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
        #endregion Properties
    }
}
