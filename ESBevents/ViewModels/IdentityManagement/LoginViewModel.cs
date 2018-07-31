using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESBevents.Models;
using ESBevents.Services;

namespace ESBevents.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
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
        public string NewPasswordHashed;

        private IdentityModel _currentUser;
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
        #endregion Properties

        #region Methods
        public async Task<string> GetIdentityAsync()
        {
            // Assume no success
            var result = string.Empty;

            // Dan met de velden de webservice aanroepen.
            var identityServicesClient = new PubsubServices();

            var identityObj = await identityServicesClient.GetIdentityAsync(this);

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
            Debug.WriteLine("DXCPS - LoginViewModel.PostSessionAsync()");

            // Assume no success
            var sessionToken = string.Empty;

            // Dan met de velden de webservice aanroepen.
            var client = new PubsubServices();

            var identityObj = await client.PostSessionAsync(CurrentUser.Username);

            if (identityObj != null)
            {
                if (identityObj.Sessiontoken != null)
                {
                    sessionToken = identityObj.Sessiontoken;
                }
            }

            return sessionToken;
        }
        #endregion Methods
    }
}
