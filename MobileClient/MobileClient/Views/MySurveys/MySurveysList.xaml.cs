using System;
using MobileClient.Controllers;
using MobileClient.Services;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.MySurveys
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MySurveysList : ContentPage
    {
        public ListViewController<SurveyDto> ListViewController;

        public MySurveysList()
        {
            InitializeComponent();
            ListViewController = new ListViewController<SurveyDto>(SystemApi.SurveysClient.SurveysMySurveysGetAsync, ListView, SearchBar);
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            ListViewController.ReloadData();
            base.OnAppearing();
        }

        private void AddItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateSurvey());
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new CreateSurvey((SurveyDto)e.Item));
        }

        private void SwipeItem_OnInvoked(object sender, EventArgs e)
        {
            Console.WriteLine("lol");
        }
    }
}