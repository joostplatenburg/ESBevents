using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESBevents.Models;
using ESBevents.Services;

namespace ESBevents.ViewModels
{
    public class IdentityViewModel : INotifyPropertyChanged
    {
        public IdentityViewModel()
        {
            Initialize();
        }

        public IdentityViewModel(IdentitiesViewModel idsvm)
        {
            SelectedItem = idsvm.SelectedItem;
            Logo = idsvm.Logo;

            GetIdentityExt();

            Initialize();
        }

        internal void Initialize()
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
        IdentityModel _currentUser;
        public string NewPasswordHashed;

        public IdentityModel CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (_currentUser == value)
                    return;

                _currentUser = value;

                OnPropertyChanged("CurrentUser");
            }
        }

        ObservableCollection<SessionModel> _sessions;
        public ObservableCollection<SessionModel> Sessions
        {
            get { return _sessions; }

            set
            {
                if (_sessions == value)
                    return;

                _sessions = value;

                OnPropertyChanged("Sessions");
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

        IdentityModel _identityExt;
        public IdentityModel IdentityExt
        {
            get { return _identityExt; }

            set
            {
                if (_identityExt == value)
                    return;

                _identityExt = value;

                Sessions = _identityExt.Sessions;

                OnPropertyChanged("IdentityExt");
                OnPropertyChanged("Sessions");
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

        SessionModel _selectedSession;
        public SessionModel SelectedSession
        {
            get { return _selectedSession; }
            set
            {
                if (_selectedSession == value)
                    return;
                
                _selectedSession = value;

                OnPropertyChanged("SelectedSession");
            }
        }

        string _currentversion;
        public string CurrentVersion
        {
            get { return _currentversion; }
            set
            {
                if (_currentversion == value)
                    return;

                _currentversion = value;

                OnPropertyChanged("CurrentVersion");
            }
        }

        public bool ShowStackApproved
        {
            get
            {
                return (bool)!IdentityExt.Approved;
            }
        }

        #endregion Properties

        #region Methods
        public async Task<string> GetIdentityAsync()
        {
            // Assume no success
            var result = string.Empty;

            // Dan met de velden de webservice aanroepen.
            var identityServicesClient = new PubsubServices();

            var identityObj = await identityServicesClient.GetIdentityAsync(CurrentUser.Username);

            if (identityObj != null)
            {
                if (identityObj.Password != null)
                {
                    result = identityObj.Password;
                }
            }

            return result;
        }

        public async Task<string> PostSessionAsync()
        {
            // Assume no success
            var sessionToken = string.Empty;

            // Dan met de velden de webservice aanroepen.
            var identityServicesClient = new PubsubServices();

            var identityObj = await identityServicesClient.PostSessionAsync(this);

            if (identityObj != null)
            {
                if (identityObj.Sessiontoken != null)
                {
                    sessionToken = identityObj.Sessiontoken;
                }
            }

            return sessionToken;
        }
        public async Task<bool> ApproveIdentity()
        {
            // Assume no success
            var result = false;

            // Dan met de velden de webservice aanroepen.
            var identityServicesClient = new PubsubServices();
            var status = await identityServicesClient.ApproveAsync(this);

            if (status == HttpStatusCode.Continue)
            {
                // De json die terug komt in vm zetten van door het object door te geven.
                result = true;
            }

            return result;
        }

        private async void GetIdentityExt()
        {
            // Dan met de velden de webservice aanroepen.
            var webSrvc = new PubsubServices();
            var status = await webSrvc.GetIdentityExtAsync(this);

            if (status == HttpStatusCode.Continue)
            {
                Sessions = IdentityExt.Sessions.OrderByDescending(i => i.Id) as ObservableCollection<SessionModel>;

            }
        }
        #endregion Methods
    }
}
