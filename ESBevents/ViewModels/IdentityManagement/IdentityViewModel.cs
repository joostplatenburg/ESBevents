using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using ESBevents.Models;
using ESBevents.WebServices;

namespace ESBevents.ViewModels
{
    public class IdentityViewModel : INotifyPropertyChanged
    {
        public IdentityViewModel()
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
        UserModel _currentUser;
        internal string NewPasswordHashed;

        public UserModel CurrentUser
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
        #endregion Properties

        #region Methods
        public async Task<string> GetIdentityAsync()
        {
            // Assume no success
            var result = string.Empty;

            // Dan met de velden de webservice aanroepen.
            var identityServicesClient = new IdentityServices(this);
            var identityObj = await identityServicesClient.GetIdentityAsync();

            if (identityObj != null)
            {
                if (identityObj.Password != null)
                {
                    result = identityObj.Password;
                }
            }

            return result;
        }

        public async Task<bool> RegisterUserAsynv()
        {
            // Assume no success
            var result = false;

            // Dan met de velden de webservice aanroepen.
            var identityServicesClient = new IdentityServices(this);
            var status = await identityServicesClient.RegisterAsync();

            if (status == HttpStatusCode.Continue)
            {
                // De json die terug komt in vm zetten van door het object door te geven.
                result = true;
            }

            return result;
        }

        public async Task<bool> ChangePasswordAsync()
        {
            // Assume no success
            var result = false;

            // Dan met de velden de webservice aanroepen.
            var identityServicesClient = new IdentityServices(this);
            var status = await identityServicesClient.ChangePasswordAsync();

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
