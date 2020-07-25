using System;
using MobileClient.Helpers;
using MobileClient.Views;
using Xamarin.Forms;

namespace MobileClient
{
    public partial class App : Application
    {
        public static string AppName { get; } = "StudentSurveySystemMobile";


        public App()
        {
            InitializeComponent();
            MapsterConfig.Setup();
        }

        protected override async void OnStart()
        {
            if (await UserHelper.AutoLogin())
            {
                MainPage = new MainPage();
            }
            else
            {
                var navAuthPage = new AuthPage();
                MainPage = navAuthPage;
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            var data = uri.ToString().ToLowerInvariant();

            if (MainPage is AuthPage)
            {
                var queryDictionary = System.Web.HttpUtility.ParseQueryString(uri.Query);

                if (queryDictionary["oauth_verifier"] == null)
                    return;

                var oAuthVerifier = queryDictionary["oauth_verifier"];

                ((AuthPage) MainPage).UsosLogin(oAuthVerifier);
            }
            else 
                return;

            base.OnAppLinkRequestReceived(uri);
        }
    }
}
