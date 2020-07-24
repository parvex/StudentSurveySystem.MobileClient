using System;
using System.Threading.Tasks;
using IO.Swagger.Model;
using MobileClient.Controllers;
using MobileClient.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.MySurveys
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MySurveysList : ContentPage
    {
        public ListViewController<SurveyListItemDto> ListViewController;

        public MySurveysList()
        {
            InitializeComponent();
            ListViewController = new ListViewController<SurveyListItemDto>(SystemApi.SurveysClient.SurveysMySurveysGetAsync, ListView, SearchBar);
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            ListViewController.ReloadData();
            base.OnAppearing();
        }

        private void AddItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateSurvey());
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(((SurveyListItemDto) e.Item).Status == SurveyStatus.Draft)
                Navigation.PushAsync(new CreateSurvey(((SurveyListItemDto)e.Item).Id.Value));
        }
    }
}