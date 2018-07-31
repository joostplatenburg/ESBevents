using System;
using System.Diagnostics;
using System.Net;
using ESBevents.ViewModels;
using ESBevents.Services;
using Xamarin.Forms;
using ESBevents.Views.IdentityManagement;
using System.Threading.Tasks;

namespace ESBevents.Views
{
    public partial class ActionsView : ContentPage
    {
        public ActionsViewModel vm = new ActionsViewModel();

        public ActionsView()
        {
            Debug.WriteLine("DXCPS - ActionView()");
            
            InitializeComponent();

            Initialize();
        }

        public ActionsView(MainPageViewModel mpvm)
        {
            Debug.WriteLine("DXCPS - ActionView(MainPageViewModel)");

            InitializeComponent();

            vm = new ActionsViewModel(mpvm);

            vm.Customer = mpvm.Customer;

            Initialize();
        }

        void Initialize()
        {
            Debug.WriteLine("DXCPS - ActionView.Initialize()");

            BindingContext = vm;

            if (vm.Customer != null)
            {
                vm.psCommands = true;
                vm.elCommands = false;
                vm.sbCommands = false;
                vm.idCommands = false;

                psStack.GestureRecognizers.Add(
                    new TapGestureRecognizer()
                    {
                        Command = new Command(() =>
                        {
                            vm.psCommands = !vm.psCommands;
                            Debug.WriteLine("clicked stack ps");
                        })
                    });

                elStack.GestureRecognizers.Add(
                    new TapGestureRecognizer()
                    {
                        Command = new Command(() =>
                        {
                            vm.elCommands = !vm.elCommands;
                            Debug.WriteLine("clicked stack el");
                        })
                    });

                sbStack.GestureRecognizers.Add(
                     new TapGestureRecognizer()
                     {
                         Command = new Command(() =>
                         {
                             vm.sbCommands = !vm.sbCommands;
                             Debug.WriteLine("clicked stack sb");
                         })
                     });

                idStack.GestureRecognizers.Add(
                     new TapGestureRecognizer()
                     {
                         Command = new Command(() =>
                         {
                             vm.idCommands = !vm.idCommands;
                             Debug.WriteLine("clicked stack id");
                         })
                     });
            }
        }

        void OnClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OptionView(vm.Customers));
        }

        async void ToonEventLog(object sender, EventArgs e)
        {
            var but = sender as Button;
            vm.Environment = but.Text;

            // Dan met de velden de webservice aanroepen.
            var webSrvc = new EnsembleENSServices(vm);
            var status = await webSrvc.GetEventlogAsync();

            if (status == HttpStatusCode.Continue)
            {
                // De json die terug komt in vm zetten van door het object door te geven.
                await Navigation.PushAsync(new EventlogView(vm));
            }

            //((ListView)sender).SelectedItem = null;
        }

        async void StartProcess(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProcessStartView(vm));

            //((ListView)sender).SelectedItem = null;
        }

        async void ToonPubsubKoppelingen(object sender, EventArgs e)
        {
            var but = sender as Button;
            vm.Environment = but.Text;

            await Navigation.PushAsync(new DeliveryStatusView(vm));

            //((ListView)sender).SelectedItem = null;
        }

        async void ListCustomersClicked(object sender, EventArgs e)
        {
            var but = sender as Button;

            await Navigation.PushAsync(new ListCustomersView(vm));
        }

        async void ListIdentitiesClicked(object sender, EventArgs e)
        {
            var but = sender as Button;

            await Navigation.PushAsync(new IdentitiesView(vm));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
