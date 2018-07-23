using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ESBevents.Models;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents.Views.IdentityManagement
{
    public partial class IdentitiesView : ContentPage
    {
        MainPageViewModel mpvm;
        IdentitiesViewModel vm;

        public IdentitiesView()
        {
            InitializeComponent();

            vm = new IdentitiesViewModel();

            Initialize();
        }

        public IdentitiesView(MainPageViewModel _mpVM)
        {
            InitializeComponent();

            vm = new IdentitiesViewModel();
            mpvm = _mpVM;

            Initialize();
        }

        public IdentitiesView(ActionsViewModel _avm)
        {
            InitializeComponent();

            vm = new IdentitiesViewModel(_avm);
            vm.Logo = _avm.Customer.Logo;

            Initialize();
        }

        void Initialize()
        {
            BindingContext = vm;

            identitiesList.ItemTapped += (sender, e) =>
            {
                Navigation.PushAsync(new IdentityView(vm));

                ((ListView)sender).SelectedItem = null;
            };
        }

        #region Methods
        void OnClick(object sender, EventArgs e)
        {
            var Customers = new ObservableCollection<CustomerModel>();

            Navigation.PushAsync(new OptionView(Customers));
        }

        void OnFilterAllClicked(object sender, EventArgs e)
        {
            vm.FilterValue = "";

        }

        void OnFilterApprovedClicked(object sender, EventArgs e)
        {
            vm.FilterValue = "Approved";

        }

        void OnFilterNotApprovedClicked(object sender, EventArgs e)
        {
            vm.FilterValue = "NotApproved";

        }
        #endregion Methods
    }
}
