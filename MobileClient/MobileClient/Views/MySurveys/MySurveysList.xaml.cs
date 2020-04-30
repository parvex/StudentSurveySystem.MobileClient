using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Acr.UserDialogs;
using MobileClient.Services;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.MySurveys
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MySurveysList : ContentPage
    {
        private ObservableCollection<SurveyDto> Surveys;

        public MySurveysList()
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
    }
}