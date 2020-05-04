using System.Collections.Generic;
using Acr.UserDialogs;
using MobileClient.Controllers;
using MobileClient.Services;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletedSurveysPage : ContentPage
    {
        public ListViewController<SurveyResponseDetailsDto> ListViewController { get; set; }

        public CompletedSurveysPage()
        {
            InitializeComponent();
            BindingContext = this;
            ListViewController = new ListViewController<SurveyResponseDetailsDto>(SystemApi.SurveyResponsesClient.SurveyResponsesMyCompletedGetAsync, ListView, SearchBar);
        }

        protected override async void OnAppearing()
        {
            ListViewController.ReloadData();
            base.OnAppearing();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new CompletedSurveyDetailsPage((SurveyResponseDetailsDto) e.SelectedItem));
        }
    }
}