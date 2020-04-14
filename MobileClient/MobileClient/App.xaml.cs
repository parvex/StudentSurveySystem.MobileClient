using System;
using MobileClient.Views;
using Xamarin.Forms;

namespace MobileClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var navPage = new NavigationPage(new MenuPage());
            navPage.PushAsync(new AuthPage());
            MainPage = navPage;
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



            if (((NavigationPage) MainPage).CurrentPage is AuthPage)
            {
                var queryDictionary = System.Web.HttpUtility.ParseQueryString(uri.Query);

                if (queryDictionary["oauth_verifier"] == null)
                    return;

                var oAuthVerifier = queryDictionary["oauth_verifier"];

                ((AuthPage) ((NavigationPage)MainPage).CurrentPage).UsosLogin(oAuthVerifier);
            }
            else 
                return;


            base.OnAppLinkRequestReceived(uri);
        }
    }
}
