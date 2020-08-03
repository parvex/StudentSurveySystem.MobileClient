using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Model;
using MobileClient.Services;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletedSurveyDetailsPage : ContentPage
    {
        public SurveyResponseDetailsDto SurveyResponse { get; set; }
        public bool Anonymous { get; set; }

        public CompletedSurveyDetailsPage(int id)
        {
            InitializeComponent();
            Init(id);
            BindingContext = this;
        }

        private void ProcessValuesToShow()
        {
            if (SurveyResponse.Answers == null || SurveyResponse.Answers.Count == 0)
            {
                Anonymous = true;
            }
            else
            {
                foreach (var answer in SurveyResponse.Answers)
                {
                    if (answer.QuestionType == QuestionType.MultipleSelect)
                        answer.Value = string.Join(", ", JsonConvert.DeserializeObject<List<StringDoubleNullableValueTuple>>(answer.Value).Select(x => x.Item1).ToList());
                    else if (answer.QuestionType == QuestionType.Date && answer.Value != null)
                        answer.Value = DateTime.ParseExact(answer.Value, "MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                    else if (answer.QuestionType == QuestionType.Boolean)
                        answer.Value = answer.Value == "True" ? "yes" : "no";
                    else if (answer.QuestionType == QuestionType.SingleSelect)
                        answer.Value = JsonConvert.DeserializeObject<StringDoubleNullableValueTuple>(answer.Value).Item1;
                    else if (answer.QuestionType == QuestionType.ValuedSingleSelect)
                    {
                        var tuple = JsonConvert.DeserializeObject<StringDoubleNullableValueTuple>(answer.Value);
                        answer.Value = tuple.Item1;
                    }
                       
                }
            }
        }

        public async Task Init(int id)
        {
            SurveyResponse = await SystemApi.SurveyResponsesClient.SurveyResponsesDetailsIdGetAsync(id);
            ProcessValuesToShow();
        }
    }
}