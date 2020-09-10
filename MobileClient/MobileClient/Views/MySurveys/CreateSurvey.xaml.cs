using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Acr.UserDialogs;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using Mapster;
using MobileClient.Extensions;
using MobileClient.Services;
using MobileClient.Views.FillSurveys;
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

        public List<SemesterDto> Semesters { get; set; }
        public SemesterDto SelectedSemester { get; set; }
        public CourseDto SelectedCourse { get; set; }

        public DateTime MinimumDate => DateTime.Now.SetHours(0, 0 ,0, 0);

        public void Initialize(bool isNew = false)
        {
            DeleteCommand = new Command<object>(DeleteQuestion);
            LoadData(isNew);
            BindingContext = this;
        }

        public CreateSurvey(bool isTemplate = false)
        {
            InitializeComponent();
            Survey = (SurveyDto) FormatterServices.GetUninitializedObject(typeof(SurveyDto));
            Survey.IsTemplate = isTemplate;
            QuestionsList = new ObservableCollection<QuestionModel>();
            Initialize(true);
        }

        public CreateSurvey(int id)
        {
            InitializeComponent();
            Survey = SystemApi.SurveysClient.SurveysIdGet(id);
            QuestionsList = Survey.Questions != null
                ? new ObservableCollection<QuestionModel>(Survey.Questions.OrderBy(x => x.Index).Select(x => new QuestionModel(x)))
                : new ObservableCollection<QuestionModel>();
            Initialize(false);
        }

        private async void AddQuestion_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestionForm(QuestionsList));
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new QuestionForm((QuestionModel)e.Item, QuestionsList));
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
            await Submit();
        }

        private async void StartActiveSurvey_OnClicked(object sender, EventArgs e)
        {
            using (UserDialogs.Instance.Loading())
            {
                FillSurveyObject();
                try
                {
                    await SystemApi.SurveysClient.SurveysStartSurveyFromTemplatePostAsync(Survey);
                    await Navigation.PopAsync();
                }
                catch (ApiException exception)
                {
                    SystemApi.HandleException(exception);
                }
            }
        }

        private async Task LoadData(bool isNew = false)
        {
            using (UserDialogs.Instance.Loading())
            {
                Semesters = await SystemApi.UsersClient.UsersGetSemestersAndMyCoursesGetAsync();
                if (!isNew)
                {
                    SelectedSemester = Semesters.First(x => x.Courses != null && x.Courses.Any(c => c.Id == Survey.CourseId));
                    SelectedCourse = Semesters.SelectMany(x => x.Courses).First(x => x.Id == Survey.CourseId);
                }
            }
        }

        private async void Activate_OnClicked(object sender, EventArgs e)
        {
            await Submit(true);
        }

        private async Task Submit(bool activate = false)
        {
            using (UserDialogs.Instance.Loading())
            {
                FillSurveyObject();
                try
                {
                    if (Survey.Id.HasValue)
                        await SystemApi.SurveysClient.SurveysIdPutAsync(Survey.Id, Survey, activate);
                    else
                        await SystemApi.SurveysClient.SurveysPostAsync(Survey, activate);

                    await Navigation.PopAsync();
                }
                catch (ApiException exception)
                {
                    SystemApi.HandleException(exception);
                }
            }
        }

        private void FillSurveyObject()
        {
            if (Survey?.EndDate != null) Survey.EndDate = Survey.EndDate.Value.SetHours(23, 59, 59, 999);
            Survey.Questions = QuestionsList.Select(x =>
            {
                var question = x.Adapt<QuestionDto>();
                question.Index = x.Index;
                return x.Adapt<QuestionDto>();
            }).ToList();
            Survey.CourseId = SelectedCourse?.Id;
        }

        private void Test_OnClicked(object sender, EventArgs e)
        {
            FillSurveyObject();
            Navigation.PushAsync(new SurveyForm(Survey));
        }
    }
}