using IO.Swagger.Model;
using MobileClient.Controllers;
using MobileClient.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletedSurveysPage : ContentPage
    {
        public ListViewController<SurveyResponseListItemDto> ListViewController { get; set; }

        public CompletedSurveysPage()
        {
            InitializeComponent();
            BindingContext = this;
            ListViewController = new ListViewController<SurveyResponseListItemDto>(SystemApi.SurveyResponsesClient.SurveyResponsesMyCompletedGetAsync, ListView, SearchBar);
        }

        protected override async void OnAppearing()
        {
            ListViewController.ReloadData();
            base.OnAppearing();
        }

        private void ListView_OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new CompletedSurveyDetailsPage(((SurveyResponseListItemDto) e.Item).Id.Value));
        }
    }
}