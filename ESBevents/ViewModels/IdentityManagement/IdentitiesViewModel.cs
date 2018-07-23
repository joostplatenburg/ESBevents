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
    public class IdentitiesViewModel : INotifyPropertyChanged
    {
        public IdentitiesViewModel()
        {
            //_identities = new ObservableCollection<IdentityModel>();
        }

        public IdentitiesViewModel(ActionsViewModel _avm)
        {
            _identities = new ObservableCollection<IdentityModel>();
            _identitiesall = new ObservableCollection<IdentityModel>();

            GetIdentities();
        }

        private async void GetIdentities()
        {
            // Dan met de velden de webservice aanroepen.
            var webSrvc = new PubsubServices();
            var identities = await webSrvc.GetIdentitiesAsync(this);

            foreach(IdentityModel im in identities)
            {
                Identities.Add(im);
                IdentitiesAll.Add(im);
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

                OnPropertyChanged("Identities");
            }
        }

        ObservableCollection<IdentityModel> _identitiesall;
        public ObservableCollection<IdentityModel> IdentitiesAll
        {
            get { return _identitiesall; }

            set
            {
                if (_identitiesall == value)
                    return;

                _identitiesall = value;

                OnPropertyChanged("IdentitiesAll");
            }
        }

        ObservableCollection<IdentityModel> _identities;
        public ObservableCollection<IdentityModel> Identities
        {
            get
            {
                List<IdentityModel> list = new List<IdentityModel>();

                if (!string.IsNullOrWhiteSpace(FilterValue))
                {
                    if (FilterValue == "Approved")
                    {
                        list = _identitiesall.Where(el => el.Approved == true).ToList();
                    } else if (FilterValue == "NotApproved") {
                        list = _identitiesall.Where(el => el.Approved == false).ToList();
                    }

                } else {
                    list = _identitiesall.ToList();
                }

                _identities.Clear();

                foreach (IdentityModel im in list)
                {
                    _identities.Add(im);
                }
                return _identities;
            }

            set
            {
                if (_identities == value)
                    return;

                _identities = value;

                OnPropertyChanged("Identities");
            }
        }

        IdentityModel _selectedItem;
        public IdentityModel SelectedItem
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
