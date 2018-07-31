using ESBevents.Models;
using Xamarin.Forms;

namespace ESBevents
{
	public partial class App : Application
	{
        public static bool IsUserLoggedIn { get; set; }

        public static int ScreenWidth;
        public static int ScreenHeight;

        public static IdentityModel CurrentUser = new IdentityModel();
        public static string SessionToken = string.Empty;

		public App()
		{
			InitializeComponent();

            Application.Current.Properties["SessionToken"] = "";

            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new ESBevents.Views.IdentityManagement.LoginView())
                {
                    //BarBackgroundColor = Color.FromHex("#806699"),
                    BarBackgroundColor = Color.Black,
                    BarTextColor = Color.White,
                    Title = "ESB Eventlogs"
                };
            } else {
                MainPage = new NavigationPage(new ESBevents.Views.MainPageView())
                {
                    //BarBackgroundColor = Color.FromHex("#806699"),
                    BarBackgroundColor = Color.Black,
                    BarTextColor = Color.White,
                    Title = "ESB Eventlogs"
                };
            }
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
