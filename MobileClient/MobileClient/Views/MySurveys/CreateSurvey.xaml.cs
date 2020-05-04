using System;
using MobileClient.Views.MySurveys;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateSurvey : ContentPage
    {
        private SurveyDto Survey;

        public CreateSurvey()
        {
            InitializeComponent();
            Survey = new SurveyDto();
        }

        public CreateSurvey(SurveyDto survey)
        {
            InitializeComponent();
            Survey = survey;
        }

        private void AddQuestion_OnClicked(object sender, EventArgs e)
        {
            var question = new QuestionDto();
            Survey.Questions.Add(question);
            Navigation.PushAsync(new QuestionForm(question));
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new QuestionForm((QuestionDto) e.SelectedItem));
        }
    }
}