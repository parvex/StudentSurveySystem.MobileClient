﻿using System.Collections.Generic;
using Acr.UserDialogs;
using Core.Models.SurveyResponse;
using MobileClient.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllResponses : ContentPage
    {
        public IList<SurveyResponseDetailsDto> SurveyResponses { get; set; } = new List<SurveyResponseDetailsDto>();

        public AllResponses()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                SurveyResponses = await SystemApi.GetSurveyResponses();
                ListView.ItemsSource = SurveyResponses;
            }
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new CompletedSurveyDetailsPage(e.SelectedItem as SurveyResponseDetailsDto));
        }
    }
}