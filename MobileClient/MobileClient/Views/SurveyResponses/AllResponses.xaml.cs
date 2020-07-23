using System.Collections.Generic;
using Acr.UserDialogs;
using IO.Swagger.Model;
using MobileClient.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllResponses : ContentPage
    {
        public IList<SurveyResponseListItemDto> SurveyResponses { get; set; } = new List<SurveyResponseListItemDto>();

        public AllResponses()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                SurveyResponses = await SystemApi.SurveyResponsesClient.SurveyResponsesGetAsync();
                ListView.ItemsSource = SurveyResponses;
            }
        }

        private void ListView_OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new CompletedSurveyDetailsPage((e.Item as SurveyResponseListItemDto).Id.Value));
        }
    }
}