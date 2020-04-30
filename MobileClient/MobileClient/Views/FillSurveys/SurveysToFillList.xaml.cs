using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Acr.UserDialogs;
using MobileClient.Services;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Extended;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SurveysToFillList : ContentPage
    {
        public InfiniteScrollCollection<SurveyDto> Surveys { get; set; }
        private const int PageSize = 20;


        public SurveysToFillList()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            LoadData();
        }

        private async void LoadData(string filter = "")
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                Surveys = new InfiniteScrollCollection<SurveyDto>
                {
                    OnLoadMore = async () =>
                    {
                        var page = Surveys.Count / PageSize;
                        var items = await SystemApi.SurveysClient.SurveysMyNotFilledFormGetAsync(filter, page + 1, PageSize);

                        return items;
                    }
                };
                await Surveys.LoadMoreAsync();
                ListView.ItemsSource = Surveys;
            }
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new SurveyPage(e.SelectedItem as SurveyDto));
        }

        private async void FilterText_OnSearchButtonPressed(object sender, EventArgs e)
        {
            var searchBar = (SearchBar) sender;
            LoadData(searchBar.Text);

        }

        private async void FilterText_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchBar = (SearchBar)sender;
            if (searchBar.Text == "")
                LoadData(searchBar.Text);
        }
    }
}