﻿using System.Collections.Generic;
using Acr.UserDialogs;
using MobileClient.Services;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SurveyListPage : ContentPage
    {
        public IList<SurveyDto> Surveys { get; set; }

        public SurveyListPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                Surveys = await SystemApi.SurveysClient.SurveysMyNotFilledFormGetAsync();
                ListView.ItemsSource = Surveys;
            }
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new SurveyPage(e.SelectedItem as SurveyDto));
        }
    }
}