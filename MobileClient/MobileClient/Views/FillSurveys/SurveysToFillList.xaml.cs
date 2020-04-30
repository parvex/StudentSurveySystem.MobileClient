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
        public ObservableCollection<SurveyDto> Surveys { get; set; }

        public SurveysToFillList()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                Surveys = new ObservableCollection<SurveyDto>(await SystemApi.SurveysClient.SurveysMyNotFilledFormGetAsync());
                this.ListView.ItemsSource = Surveys;
            }
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new SurveyPage(e.SelectedItem as SurveyDto));
        }
    }
}