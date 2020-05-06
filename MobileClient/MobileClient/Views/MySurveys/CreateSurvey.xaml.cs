using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        public ObservableCollection<QuestionDto> QuestionsList { get; set; }
        public Command<object> DeleteCommand { get; set; }

        public CreateSurvey()
        {
            InitializeComponent();
            Survey = new SurveyDto();
            QuestionsList = new ObservableCollection<QuestionDto>();
            DeleteCommand = new Command<object>(DeleteQuestion);
            BindingContext = this;
        }

        public CreateSurvey(SurveyDto survey)
        {
            InitializeComponent();
            Survey = survey;
            QuestionsList = survey.Questions != null
                ? new ObservableCollection<QuestionDto>(survey.Questions.OrderBy(x => x.Index))
                : new ObservableCollection<QuestionDto>();
            DeleteCommand = new Command<object>(DeleteQuestion);
            BindingContext = this;
        }

        private void AddQuestion_OnClicked(object sender, EventArgs e)
        {
            var question = new QuestionDto();
            Navigation.PushAsync(new QuestionForm(QuestionsList));
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new QuestionForm((QuestionDto)e.Item, QuestionsList));
        }

        private void DeleteQuestion(object obj)
        {
            var question = obj as QuestionDto;
            QuestionsList.Remove(question);
        }
    }
}