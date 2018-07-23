﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ESBevents.ViewModels
{
    public class EventlogViewModel : INotifyPropertyChanged
    {
        public EventlogViewModel()
        {
            _eventlog = new ObservableCollection<EventViewModel>();
        }

        public EventlogViewModel(ActionsViewModel _cVM)
        {
            _eventlog = new ObservableCollection<EventViewModel>();
            _eventlogall = new ObservableCollection<EventViewModel>();

            foreach (EventModel e in _cVM.Eventlog)
            {
                if (
                    (!e.SourceClass.StartsWith("Ens.", StringComparison.CurrentCulture)) &&
                    (!e.SourceClass.StartsWith("EnsLib", StringComparison.CurrentCulture)) // &&
                                                                                           // (!e.SourceClass.StartsWith("DXC.", StringComparison.CurrentCulture))
                )
                {
                    _eventlog.Add(new EventViewModel { Event = e });
                    _eventlogall.Add(new EventViewModel { Event = e });
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
        string _filterValue;
        public string FilterValue
        {
            get { return _filterValue; }
            set
            {
                if (_filterValue == value)
                    return;

                _filterValue = value;

                OnPropertyChanged("Eventlog");
            }
        }

        ObservableCollection<EventViewModel> _eventlogall;
        public ObservableCollection<EventViewModel> EventlogAll
        {
            get { return _eventlogall; }

            set
            {
                if (_eventlogall == value)
                    return;

                _eventlogall = value;

                OnPropertyChanged("EventlogAll");
            }
        }
        ObservableCollection<EventViewModel> _eventlog;
        public ObservableCollection<EventViewModel> Eventlog
        {
            get
            {
                List<EventViewModel> list;

                if (!string.IsNullOrWhiteSpace(FilterValue))
                {
                    list = _eventlogall.Where(el => el.MsgType == FilterValue).ToList();

                } else {
                    list = _eventlogall.ToList();
                }

                _eventlog.Clear();

                foreach (EventViewModel evm in list)
                {
                    _eventlog.Add(evm);
                }
                return _eventlog;
            }

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
