using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Acr.UserDialogs;
using IO.Swagger.Client;
using IO.Swagger.Model;
using MobileClient.Extensions;
using MobileClient.Services;
using MobileClient.Templates;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.FillSurveys
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SurveyForm : ContentPage
    {
        private SurveyDto Survey { get; set; }
        private readonly List<(Label, View, QuestionDto, Label)> _controlList = new List<(Label, View, QuestionDto, Label)>();

        public SurveyForm(int surveyId)
        {
            InitializeComponent();
            BindingContext = this;
            Survey = SystemApi.SurveysClient.SurveysIdGet(surveyId);
            SurveyNameLabel.Text = Survey.Name;
            Survey.Questions = Survey.Questions.OrderBy(x => x.Index).ToList();
            foreach (var question in Survey.Questions)
            {
                var controls = CreateControlAndLabelForQuestion(question);
                _controlList.Add(controls);
                FormControlsLayout.Children.Add(controls.Item1);
                FormControlsLayout.Children.Add(controls.Item2);
                FormControlsLayout.Children.Add(controls.Item4);
            }
        }

        private (Label, View, QuestionDto, Label) CreateControlAndLabelForQuestion(QuestionDto question)
        {
            var label = new Label() {Text = question.Index + ". " + question.QuestionText};
            label.Style = (Style) Application.Current.Resources["FormLabel"];
            var validationLabel = new Label() {TextColor = Color.Red, IsVisible = false};
            View control;
            switch (question.QuestionType)
            {
                case QuestionType.Text:
                    var text = new Entry();
                    text.Text = "";
                    text.TextChanged += ValidateText;
                    control = text;
                    break;
                case QuestionType.Numeric:
                    var numeric = new Entry() {Keyboard = Keyboard.Numeric};
                    numeric.TextChanged += ValidateNumeric;
                    if(question.ValidationConfig.Integer == true)
                        numeric.Behaviors.Add(new IntegerValidationBehavior());
                    control = numeric;
                    break;
                case QuestionType.Date:
                    var date = new NullableDateView();
                    date.DateChanged += ValidateDate;
                    control = date;
                    break;
                case QuestionType.Boolean:
                    var boolean = new CheckBox();
                    control = boolean;
                    break;
                case QuestionType.SingleSelect:
                case QuestionType.ValuedSingleSelect:
                    var singleSelect = new Picker()
                    {
                        ItemsSource = question.Values.Select(x => x.Item1).ToList(), 
                    };
                    control = singleSelect;
                    break;
                case QuestionType.MultipleSelect:
                    var multiSelect = new MultiSelectPicker()
                    {
                        ItemsSource = question.Values.Select(x => x.Item1).ToList()
                    };
                    control = multiSelect;
                    break;
                default:
                    control = new Entry();
                    break;
            }
            return (label, control, question, validationLabel);
        }

        private void ValidateText(object sender, TextChangedEventArgs e)
        {
            var control = (Entry) sender;
            var (_, _, question, validationLabel) = _controlList.Find(x => x.Item2 == control);
            var regexString = question.ValidationConfig.Regex;
            if (regexString == null) return;
            regexString = "^" + regexString + "$";
            var match = Regex.Match(control.Text, regexString);
            validationLabel.Text = !match.Success ? $"Text doesn't match criteria - {regexString}" : null;
            validationLabel.IsVisible = !string.IsNullOrEmpty(validationLabel.Text);
        }

        private void ValidateNumeric(object sender, TextChangedEventArgs e)
        {
            var control = (Entry)sender;
            var (_, _, question, validationLabel) = _controlList.Find(x => x.Item2 == control);
            var minValue = question.ValidationConfig.MinNumericValue;
            var maxValue = question.ValidationConfig.MaxNumericValue;
            if (!minValue.HasValue && !maxValue.HasValue) return;
            var value = double.TryParse(control.Text, out var tempVal) ? tempVal : (double?)null;
            if (!value.HasValue || (minValue.HasValue && value < minValue) || (maxValue.HasValue && value > maxValue))
                validationLabel.Text = "Number should be " + (minValue.HasValue ? "from " + minValue : null) + (maxValue.HasValue ? " to " + maxValue : null);
            else
                validationLabel.Text = null;

            validationLabel.IsVisible = !string.IsNullOrEmpty(validationLabel.Text);
        }

        private void ValidateDate(object sender, EventArgs e)
        {
            var control = (NullableDateView) sender;
            var (_, _, question, validationLabel) = _controlList.Find(x => x.Item2 == control);
            var minValue = question.ValidationConfig.MinDateValue;
            var maxValue = question.ValidationConfig.MaxDateValue;
            if (!minValue.HasValue && !maxValue.HasValue) return;
            var value = control.NullableDate;
            if (!value.HasValue || (minValue.HasValue && value < minValue) || (maxValue.HasValue && value > maxValue))
                validationLabel.Text = "Date should be " + (minValue.HasValue ? "from " + minValue.Value.ToString("dd/MM/yyyy") : null) 
                                                         + (maxValue.HasValue ? " to " + maxValue.Value.Date.ToString("dd/MM/yyyy") : null);
            else
                validationLabel.Text = null;

            validationLabel.IsVisible = !string.IsNullOrEmpty(validationLabel.Text);
        }

        private SurveyResponseDto CreateSurveyResponseDtoFromData()
        {
            var surveyResponse = new SurveyResponseDto()
            {
                SurveyId = Survey.Id.Value,
                Answers = new List<AnswerDto>()
            };

            foreach (var controlTuple in _controlList)
            {
                surveyResponse.Answers.Add(CreateAnswerDto(controlTuple.Item2, controlTuple.Item3));
            }

            return surveyResponse;
        }

        private AnswerDto CreateAnswerDto(View control, QuestionDto question)
        {
            var answer = new AnswerDto {QuestionId = question.Id.Value};

            if (question.QuestionType == QuestionType.Boolean)
                answer.Value = ((CheckBox) control).IsChecked.ToString();
            else if (question.QuestionType == QuestionType.Text || question.QuestionType == QuestionType.Numeric)
                answer.Value = ((Entry)control).Text;
            else if (question.QuestionType == QuestionType.Date)
                answer.Value = ((NullableDateView)control).NullableDate?.SetHours(0, 0, 0, 0).ToString(CultureInfo.InvariantCulture);
            else if (question.QuestionType == QuestionType.MultipleSelect)
                answer.Value = JsonConvert.SerializeObject(question.Values.Where(x => ((MultiSelectPicker)control).SelectedValues.Any(y => y == x.Item1)));
            else if (question.QuestionType == QuestionType.SingleSelect || question.QuestionType == QuestionType.ValuedSingleSelect)
                answer.Value = JsonConvert.SerializeObject(question.Values.FirstOrDefault(x => x.Item1 == (string) ((Picker)control).SelectedItem));

            return answer;
        }

        private async void Button_Submit(object sender, EventArgs e)
        {
            foreach (var (_, control, questionDto, _) in _controlList)
            {
                switch (questionDto.QuestionType)
                {
                    case QuestionType.Text:
                        ValidateText(control, null);
                        break;
                    case QuestionType.Numeric:
                        ValidateNumeric(control, null);
                        break;
                    case QuestionType.Date:
                        ValidateDate(control, null);
                        break;
                }
            }

            if (_controlList.Any(x => x.Item4.Text != null))
                return;
            try
            {
                using (UserDialogs.Instance.Loading())
                {
                    await SystemApi.SurveyResponsesClient.SurveyResponsesPostAsync(CreateSurveyResponseDtoFromData());
                }

                UserDialogs.Instance.Toast("Survey sent!", TimeSpan.FromSeconds(2));
                await Navigation.PopAsync();
            }
            catch(ApiException exception)
            {
                SystemApi.HandleException(exception);
            }
        }

    }
}