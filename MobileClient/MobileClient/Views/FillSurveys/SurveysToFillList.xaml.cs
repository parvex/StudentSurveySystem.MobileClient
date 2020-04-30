using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Acr.UserDialogs;
using MobileClient.Services;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SurveysToFillList : ContentPage
    {
        public List<SurveyDto> Surveys { get; set; }

        public SurveysToFillList()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                Surveys = await SystemApi.SurveysClient.SurveysMyNotFilledFormGetAsync();
                this.ListView.ItemsSource = Surveys;
            }
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new SurveyPage(e.SelectedItem as SurveyDto));
        }

        private async void FilterText_OnSearchButtonPressed(object sender, EventArgs e)
        {
            var searchBar = (SearchBar) sender;
            using (UserDialogs.Instance.Loading("Loading"))
            {
                Surveys = await SystemApi.SurveysClient.SurveysMyNotFilledFormGetAsync(searchBar.Text);
                this.ListView.ItemsSource = Surveys;
            }
        }

        private async void FilterText_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchBar = (SearchBar)sender;
            if (searchBar.Text == "")
            using (UserDialogs.Instance.Loading("Loading"))
            {
                Surveys = await SystemApi.SurveysClient.SurveysMyNotFilledFormGetAsync(searchBar.Text);
                this.ListView.ItemsSource = Surveys;
            }
        }
    }
}