using MobileClient.Controllers;
using MobileClient.Services;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SurveysToFillList : ContentPage
    {
        public ListViewController<SurveyDto> ListViewController { get; set; }

        public SurveysToFillList()
        {
            InitializeComponent();
            BindingContext = this;
            ListViewController = new ListViewController<SurveyDto>(SystemApi.SurveysClient.SurveysMyNotFilledFormGetAsync, ListView, SearchBar);
        }

        protected override void OnAppearing()
        {
            ListViewController.ReloadData();
            base.OnAppearing();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new SurveyForm((SurveyDto) e.SelectedItem));
        }
    }
}