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
                    ((MenuPage)Navigation.NavigationStack[0]).SetData();
                    await Navigation.PopToRootAsync();
                }
                else
                    AuthErrorLabel.IsVisible = true;
            }
        }

        private void Button_LocalAccountLogin(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LocalAccountLogin());
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}