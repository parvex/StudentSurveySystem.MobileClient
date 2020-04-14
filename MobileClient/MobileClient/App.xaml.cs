using System;
using MobileClient.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace MobileClient
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            var navAuthPage = new AuthPage();
            MainPage = navAuthPage;
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
