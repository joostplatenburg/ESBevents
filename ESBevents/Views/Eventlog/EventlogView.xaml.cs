using System;
using System.Collections.Generic;
using ESBevents.Models;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents
{
    public partial class EventlogView : ContentPage
    {
        EventlogViewModel vm;

        MainPageViewModel mpvm;

        public EventlogView()
        {
            InitializeComponent();

            vm = new EventlogViewModel();

            Initialize();
        }

        public EventlogView(MainPageViewModel _mpVM)
        {
            InitializeComponent();

            vm = new EventlogViewModel();
            mpvm = _mpVM;

            Initialize();
        }

        public EventlogView(ActionsViewModel cvm)
        {
            InitializeComponent();

            vm = new EventlogViewModel(cvm);
            vm.Customer = cvm.Customer;
            vm.Customers = cvm.Customers;
            vm.Environment = cvm.Environment;
            vm.Logo = cvm.Customer.Logo;

            Initialize();
        }

        void Initialize()
        {
            BindingContext = vm;

            eventList.ItemTapped += (sender, e) =>
            {
                Navigation.PushAsync(new EventView(vm));

                ((ListView)sender).SelectedItem = null;
            };
        }

        #region Methods
        void OnClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OptionView(vm.Customers));
        }

        void OnFilterAllClicked(object sender, EventArgs e)
        {
            vm.FilterValue = "";

        }

        void OnFilterTraceClicked(object sender, EventArgs e)
        {
            vm.FilterValue = "Trace";

        }

        void OnFilterWarningClicked(object sender, EventArgs e)
        {
            vm.FilterValue = "Warning";

        }

        void OnFilterErrorClicked(object sender, EventArgs e)
        {
            vm.FilterValue = "Error";

        }

        void OnFilterInfoClicked(object sender, EventArgs e)
        {
            vm.FilterValue = "Info";

        }
        #endregion Methods
    }
}
