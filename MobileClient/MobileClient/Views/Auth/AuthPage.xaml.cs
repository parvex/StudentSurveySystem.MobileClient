using System;
using Acr.UserDialogs;
using Core.Models.Auth;
using MobileClient.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        public UsosAuthDto usosAuth;

        public bool Busy { get; set; }

        public AuthPage()
        {
            InitializeComponent();
        }


        private async void Button_UsosAuth(object sender, EventArgs e)
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                usosAuth = await SystemApi.GetUsosAuthData();
                await Launcher.OpenAsync(new Uri(usosAuth.UsosAuthUrl));
            }
        }

        public async void UsosLogin(string oAuthVerifier)
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                usosAuth.OAuthVerifier = oAuthVerifier;
                var result = await SystemApi.UsosPinAuth(usosAuth);
                if (result != null)
                {
                    Application.Current.MainPage = new MainPage();
                    await Navigation.PopToRootAsync();
                }
                else
                    AuthErrorLabel.IsVisible = true;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void Button_Login(object sender, EventArgs e)
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                var result = await SystemApi.Authenticate(Username.Text, Password.Text);
                if (result != null)
                {
                    Application.Current.MainPage = new MainPage();
                    await Navigation.PopToRootAsync();
                }
                else
                {
                    AuthErrorLabel.IsVisible = true;
                }
            }
        }
    }
}