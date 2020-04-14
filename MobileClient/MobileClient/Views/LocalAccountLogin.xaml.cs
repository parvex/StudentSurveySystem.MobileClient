using System;
using Acr.UserDialogs;
using MobileClient.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalAccountLogin : ContentPage
    {
        public LocalAccountLogin()
        {
            InitializeComponent();
        }

        private async void Button_Login(object sender, EventArgs e)
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                var result = await SystemApi.Authenticate(Username.Text, Password.Text);
                if (result != null)
                {
                    ((MenuPage) Navigation.NavigationStack[0]).SetData();
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