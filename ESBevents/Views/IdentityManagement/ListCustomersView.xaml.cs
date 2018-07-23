using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ESBevents.Models;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents.Views.IdentityManagement
{
    public partial class ListCustomersView : ContentPage
    {
        MainPageViewModel mpvm;
        ListCustomersViewModel vm;

        public ListCustomersView()
        {
            InitializeComponent();

            vm = new ListCustomersViewModel();

            Initialize();
        }

        public ListCustomersView(MainPageViewModel _mpVM)
        {
            InitializeComponent();

            vm = new ListCustomersViewModel();
            mpvm = _mpVM;

            Initialize();
        }

        public ListCustomersView(ActionsViewModel avm)
        {
            InitializeComponent();

            vm = new ListCustomersViewModel(avm);
            vm.Logo = avm.Customer.Logo;

            Initialize();
        }

        void Initialize()
        {
            BindingContext = vm;

            customersList.ItemTapped += (sender, e) =>
            {
                //Navigation.PushAsync(new CustomerView(vm));

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

        void OnFilterShowClicked(object sender, EventArgs e)
        {
            vm.FilterValue = "Show";

        }

        void OnFilterNotShowClicked(object sender, EventArgs e)
        {
            vm.FilterValue = "NotShow";

        }
        #endregion Methods
    }
}
