using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using Acr.UserDialogs;
using IO.Swagger.Client;
using IO.Swagger.Model;
using MobileClient.Services;
using MobileClient.Views.MySurveys;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateSurvey : ContentPage
    {
        public SurveyDto Survey { get; set; }
        public ObservableCollection<QuestionModel> QuestionsList { get; set; }
        public Command<object> DeleteCommand { get; set; }

        public void Initialize()
        {
            DeleteCommand = new Command<object>(DeleteQuestion);
            BindingContext = this;
        }

        public CreateSurvey()
        {
            InitializeComponent();
            Survey = (SurveyDto) FormatterServices.GetUninitializedObject(typeof(SurveyDto));
            QuestionsList = new ObservableCollection<QuestionModel>();
            Initialize();
        }

        public CreateSurvey(SurveyDto survey)
        {
            InitializeComponent();
            Survey = survey;
            QuestionsList = survey.Questions != null
                ? new ObservableCollection<QuestionModel>(survey.Questions.OrderBy(x => x.Index).Select(x => new QuestionModel(x)))
                : new ObservableCollection<QuestionModel>();
            Initialize();
        }

        private void AddQuestion_OnClicked(object sender, EventArgs e)
        {
            var question = (QuestionDto) FormatterServices.GetUninitializedObject(typeof(QuestionDto));
            Navigation.PushAsync(new QuestionForm(QuestionsList));
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new QuestionForm((QuestionModel)e.Item, QuestionsList));
        }

        private void DeleteQuestion(object obj)
        {
            var question = obj as QuestionModel;
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

                try
                {
                    if (Survey.Id.HasValue)
                        await SystemApi.SurveysClient.SurveysIdPutAsync(Survey.Id, Survey);
                    else
                        await SystemApi.SurveysClient.SurveysPostAsync(Survey);

                    await Navigation.PopAsync();
                }
                catch (ApiException exception)
                {
                    SystemApi.HandleException(exception);
                }
            }
        }
    }
}