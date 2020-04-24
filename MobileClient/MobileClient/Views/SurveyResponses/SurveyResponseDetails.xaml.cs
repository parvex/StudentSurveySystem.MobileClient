using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletedSurveyDetailsPage : ContentPage
    {
        public SurveyResponseDetailsDto SurveyResponse { get; set; }

        public CompletedSurveyDetailsPage(SurveyResponseDetailsDto surveyResponse)
        {
            InitializeComponent();
            SurveyResponse = surveyResponse;
            BindingContext = this;
            ProcessValuesToShow();
        }

        private void ProcessValuesToShow()
        {
            foreach (var answer in SurveyResponse.Answers)
            {
                if (answer.QuestionType == QuestionType.MultipleSelect)
                    answer.Value = String.Join(", ", JsonConvert.DeserializeObject<List<string>>(answer.Value));
                else if (answer.QuestionType == QuestionType.Date)
                    answer.Value = DateTime.ParseExact(answer.Value, "MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                else if (answer.QuestionType == QuestionType.Boolean)
                    answer.Value = answer.Value == "True" ? "yes" : "no"; 
            }
        }
    }
}