using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESBevents.Models;
using ESBevents.Services;

namespace ESBevents.ViewModels
{
    public class ResetPasswordViewModel : INotifyPropertyChanged
    {
        public ResetPasswordViewModel()
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

        IdentityModel _currentUser;
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

        bool _showcodestack;
        public bool ShowCodeStack
        {
            get { return _showcodestack; }
            set
            {
                if (_showcodestack == value)
                    return;

                _showcodestack = value;

                OnPropertyChanged("ShowCodeStack");
            }
        }
        #endregion Properties

        #region Methods
        public async Task<bool> GetResetCode()
        {
            // Dan met de velden de webservice aanroepen.
            var identityServicesClient = new PubsubServices();

            return await identityServicesClient.GetResetCodeAsync(CurrentUser.Username);
        }

        public async Task<IdentityModel> GetIdentityAsync()
        {
            // Dan met de velden de webservice aanroepen.
            var identityServicesClient = new PubsubServices();

            return await identityServicesClient.GetIdentityAsync(CurrentUser.Username);
        }

        public async Task<bool> ChangePasswordAsync()
        {
            // Assume no success
            var result = false;

            // Dan met de velden de webservice aanroepen.
            var identityServicesClient = new PubsubServices();
            var status = await identityServicesClient.ChangePasswordAsync(CurrentUser, NewPasswordHashed);

            if (status == HttpStatusCode.Continue)
            {
                // De json die terug komt in vm zetten van door het object door te geven.
                result = true;
            }

            return result;
        }
        #endregion Methods
    }
}
