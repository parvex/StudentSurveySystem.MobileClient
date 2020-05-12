using System;
using System.Collections.ObjectModel;
using System.Linq;
using Acr.UserDialogs;
using MobileClient.Services;
using MobileClient.Views.MySurveys;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateSurvey : ContentPage
    {
        public SurveyDto Survey { get; set; }
        public ObservableCollection<QuestioDtoModel> QuestionsList { get; set; }
        public Command<object> DeleteCommand { get; set; }

        public void Initialize()
        {
            DeleteCommand = new Command<object>(DeleteQuestion);
            BindingContext = this;
        }

        public CreateSurvey()
        {
            InitializeComponent();
            Survey = new SurveyDto();
            QuestionsList = new ObservableCollection<QuestioDtoModel>();
            Initialize();
        }

        public CreateSurvey(SurveyDto survey)
        {
            InitializeComponent();
            Survey = survey;
            QuestionsList = survey.Questions != null
                ? new ObservableCollection<QuestioDtoModel>(survey.Questions.OrderBy(x => x.Index).Select(x => new QuestioDtoModel(x)))
                : new ObservableCollection<QuestioDtoModel>();
            Initialize();
        }

        private void AddQuestion_OnClicked(object sender, EventArgs e)
        {
            var question = new QuestionDto();
            Navigation.PushAsync(new QuestionForm(QuestionsList));
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new QuestionForm((QuestioDtoModel)e.Item, QuestionsList));
        }

        private void DeleteQuestion(object obj)
        {
            var question = obj as QuestioDtoModel;
            QuestionsList.Remove(question);
            for (int i = 0; i < QuestionsList.Count; ++i)
            {
                QuestionsList[i].Index = i + 1;
            }
        }

        private async void Save_OnClicked(object sender, EventArgs e)
        {
            using (UserDialogs.Instance.Loading())
            {
                Survey.Questions = QuestionsList.Select(x =>
                {
                    var question = (QuestionDto) x;
                    question.Index = x.Index;
                    return (QuestionDto) x;
                }).ToList();
                await SystemApi.SurveysClient.SurveysIdPutAsync(Survey.Id, Survey);
                await Navigation.PopAsync();
            }
        }
    }
}