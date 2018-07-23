using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;
using Xamarin.Forms;

namespace ESBevents.ViewModels
{
    public class DeliveryViewModel : INotifyPropertyChanged
    {
        DeliverylogViewModel dlvm;

        public DeliveryViewModel()
        {
            _delivery = new DeliveryModel();
        }

        public DeliveryViewModel(DeliverylogViewModel _dlVM)
        {
            //_delivery = _elVM.SelectedDelivery;
            dlvm = _dlVM;
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
        DeliveryModel _delivery;
        public DeliveryModel Delivery
        {
            get { return _delivery; }
            set
            {
                if (_delivery == value) return;

                _delivery = value;

                OnPropertyChanged("Delivery");
                OnPropertyChanged("DeliveryStatus");
            }
        }

        public string DeliveryId { get { return string.Format("{0}", Delivery.DeliveryId); } }
        public string MessageId { get { return string.Format("{0}", Delivery.MessageId); } }
        public string CreationDate { get { return string.Format("{0}", Delivery.CreationDate); } }
        public string CreationTime { get { return string.Format("{0}", Delivery.CreationTime); } }
        public string ProcessedDate { get { return string.Format("{0}", Delivery.ProcessedDate); } }
        public string ProcessedTime { get { return string.Format("{0}", Delivery.ProcessedTime); } }
        public string SubscriptionStatus { get { return string.Format("{0}", Delivery.SubscriptionStatus); } }
        public string DeliveryStatus { get { return string.Format("{0}", Delivery.DeliveryStatus); } }
        public string NumberOfTries { get { return string.Format("{0}", Delivery.NumberOfTries); } }
        public string Resultmessage { get { return string.Format("{0}", Delivery.Resultmessage); } }
        public string PublisherName { get { return string.Format("{0}", Delivery.PublisherName); } }
        public string SubscriptionName { get { return string.Format("{0}", Delivery.SubscriptionName); } }
        public string MessageType { get { return string.Format("{0}", Delivery.MessageType); } }
        public string Messagecontent { get { return string.Format("{0}", Delivery.Messagecontent); } }

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

        string _environment;
        public string Environment
        {
            get { return _environment; }
            set
            {
                if (_environment == value) return;

                _environment = value;

                OnPropertyChanged("Environment");
            }
        }
        #endregion Properties
    }
}
