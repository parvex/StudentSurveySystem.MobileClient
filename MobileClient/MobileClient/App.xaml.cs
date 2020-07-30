using System;
using MobileClient.Extensions;
using MobileClient.Helpers;
using MobileClient.Views;
using Plugin.FirebasePushNotification;
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
            DependencyService.Get<INotificationManager>().Initialize();

            CrossFirebasePushNotification.Current.Subscribe("global");
            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"TOKEN : {p.Token}");
            };

            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                var notificationManager = DependencyService.Get<INotificationManager>();
                if (p.Data.ContainsKey("message") && p.Data.ContainsKey("title"))
                    notificationManager.ScheduleNotification((string)p.Data["title"], (string) p.Data["message"]);
            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Opened");
                foreach (var data in p.Data)
                {
                    System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                }


            };
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
