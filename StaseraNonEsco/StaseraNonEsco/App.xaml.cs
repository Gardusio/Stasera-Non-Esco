using StaseraNonEsco.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace StaseraNonEsco {
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var accesstoken = Preferences.Get("accessToken", string.Empty);
            if (string.IsNullOrEmpty(accesstoken))
            {
                MainPage = new NavigationPage(new SignupPage());
            }
            else
            {
                MainPage = new NavigationPage(new HomePage());
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
