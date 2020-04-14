using System;
using System.Collections.Generic;
using System.Globalization;
using Acr.UserDialogs;
using Core.Models.Survey;
using Core.Models.SurveyResponse;
using MobileClient.Helpers;
using MobileClient.Services;
using Newtonsoft.Json;
using Syncfusion.XForms.ComboBox;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SurveyPage : ContentPage
    {
        private SurveyDto Survey { get; set; }
        private readonly List<(Label, View, QuestionDto)> _controlList = new List<(Label, View, QuestionDto)>();

        public SurveyPage(SurveyDto survey)
        {
            InitializeComponent();
            BindingContext = this;
            Survey = survey;
            SurveyNameLabel.Text = survey.Name;
            foreach (var question in Survey.Questions)
            {
                var controls = CreateControlAndLabelForQuestion(question);
                _controlList.Add(controls);
                FormControlsLayout.Children.Add(controls.Item1);
                FormControlsLayout.Children.Add(controls.Item2);
            }
        }

        private (Label, View, QuestionDto) CreateControlAndLabelForQuestion(QuestionDto question)
        {
            var label = new Label() {Text = question.QuestionText};
            View control;
            if(question.QuestionType == QuestionType.Text)
                control = new Entry();
            else if(question.QuestionType == QuestionType.Numeric)
                control = new Entry() {Keyboard = Keyboard.Numeric};
            else if(question.QuestionType == QuestionType.Date)
                control = new DatePicker();
            else if(question.QuestionType == QuestionType.Boolean)
                control = new CheckBox();
            else if (question.QuestionType == QuestionType.SingleSelect)
                control = new SfComboBox()
                {
                    DataSource = question.Values, 
                    ComboBoxMode = ComboBoxMode.Suggest,
                };
            else if (question.QuestionType == QuestionType.MultipleSelect)
                control = new SfComboBox()
                {
                    DataSource = question.Values,
                    ComboBoxMode = ComboBoxMode.Suggest,
                    MultiSelectMode = MultiSelectMode.Token,
                    TokensWrapMode = TokensWrapMode.Wrap,
                    IsSelectedItemsVisibleInDropDown = false
                };
            else
                control = new Entry();
            return (label, control, question);
        }

        private SurveyResponseDto CreateSurveyResponseDtoFromData()
        {
            var surveyResponse = new SurveyResponseDto()
            {
                RespondentId = UserHelper.User.Id.Value,
                SurveyId = Survey.Id.Value,
                Answers = new List<AnswerDto>()
            };

            foreach (var controlTuple in _controlList)
            {
                surveyResponse.Answers.Add(CreateAnswer(controlTuple.Item2, controlTuple.Item3));
            }

            return surveyResponse;
        }

        private AnswerDto CreateAnswer(View control, QuestionDto question)
        {
            var answer = new AnswerDto {QuestionId = question.Id.Value};

            if (question.QuestionType == QuestionType.Boolean)
                answer.Value = ((CheckBox) control).IsChecked.ToString();
            else if (question.QuestionType == QuestionType.Text || question.QuestionType == QuestionType.Numeric)
                answer.Value = ((Entry)control).Text;
            else if (question.QuestionType == QuestionType.Date)
                answer.Value = ((DatePicker)control).Date.ToString(CultureInfo.InvariantCulture);
            else if (question.QuestionType == QuestionType.MultipleSelect)
                answer.Value = JsonConvert.SerializeObject(((SfComboBox)control).SelectedValue);
            else if (question.QuestionType == QuestionType.SingleSelect)
                answer.Value = ((SfComboBox)control).Text;

            return answer;
        }

        private void Button_Submit(object sender, EventArgs e)
        {
            SystemApi.PostSurveyResponse(CreateSurveyResponseDtoFromData());
            UserDialogs.Instance.Toast("Survey sent!", TimeSpan.FromSeconds(2));
            Navigation.PopToRootAsync();
        }
    }
}