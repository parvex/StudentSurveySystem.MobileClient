using System;
using IO.Swagger.Model;
using MobileClient.Controllers;
using MobileClient.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.MySurveys
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MySurveyTemplates : ContentPage
    {
        public ListViewController<SurveyListItemDto> ListViewController;

        public MySurveyTemplates()
        {
            InitializeComponent();
            ListViewController = new ListViewController<SurveyListItemDto>(SystemApi.SurveysClient.SurveysMySurveyTemplatesGetAsync, ListView, SearchBar);
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            ListViewController.ReloadData();
            base.OnAppearing();
        }

        private void AddItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateSurvey(true));
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new CreateSurvey(((SurveyListItemDto)e.Item).Id.Value));
        }
    }
}