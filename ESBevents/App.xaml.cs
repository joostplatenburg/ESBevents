using Xamarin.Forms;

namespace ESBevents
{
	public partial class App : Application
	{
        public static bool IsUserLoggedIn { get; set; }

        static public int ScreenWidth;
        static public int ScreenHeight;

		public App()
		{
			InitializeComponent();

            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new ESBevents.Views.IdentityManagement.LoginPage())
                {
                    BarBackgroundColor = Color.FromHex("#806699"),
                    BarTextColor = Color.White,
                    Title = "ESB Eventlogs"
                };
            } else {
                MainPage = new NavigationPage(new ESBevents.Views.MainPage())
                {
                    BarBackgroundColor = Color.FromHex("#806699"),
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
