using System;
using Acr.UserDialogs;
using Core.Models.Auth;
using MobileClient.Helpers;
using MobileClient.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public void SetData()
        {
            HelloLabel.Text = "Hello " +  UserHelper.User.FirstName;
            if (UserHelper.User.UserRole != UserRole.Admin && UserHelper.User.UserRole != UserRole.Lecturer)
                AllResponsesButton.IsVisible = false;
            else
                AllResponsesButton.IsVisible = true;

        }

        private void Button_NavigateSurveyList(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SurveyListPage());
        }

        private void Button_NavigateCompletedSurveys(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CompletedSurveysPage());
        }

        private void Button_NavigateAbout(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }

        private void Button_Logout(object sender, EventArgs e)
        {
            SystemApi.Logout();
            Navigation.PushAsync(new AuthPage());
        }

        private void Button_AllResponses(object sender, EventArgs e)
        {
            if (UserHelper.User.UserRole == UserRole.Admin || UserHelper.User.UserRole == UserRole.Lecturer)
            {
                Navigation.PushAsync(new AllResponses());
            }
            else
            {
                UserDialogs.Instance.Toast("You don't have enough permissions", TimeSpan.FromSeconds(4));
            }
        }
    }
}