using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Force.DeepCloner;
using MobileClient.Controllers;
using MobileClient.Extensions;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.MySurveys
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionForm : ContentPage
    {
        private readonly ObservableCollection<QuestionDto> _questionList;
        private readonly QuestionDto _originalQuestion;
        private int _index;

        public QuestionDto Question { get; set; }
        public List<string> QuestionTypes { get; } = Enum.GetNames(typeof(QuestionType)).Select(b => b.SplitCamelCase()).ToList();
        public QuestionType SelectedType { get; set; }
        public ValidationConfig ValidationConfig { get; set; }

        public string Index
        {
            get => _index.ToString();
            set => _index = int.Parse(value);
        }

        public QuestionForm(ObservableCollection<QuestionDto> questionList)
        {
            InitializeComponent();
            _questionList = questionList;
            _index = questionList.Count;
            Question = new QuestionDto();
            BindingContext = this;
        }

        public QuestionForm(QuestionDto question, ObservableCollection<QuestionDto> questionList)
        {
            InitializeComponent();
            _questionList = questionList;
            _originalQuestion = question;
            Question = _originalQuestion.DeepClone();
            if (Question.QuestionType != null) SelectedType = Question.QuestionType.Value;
            _index = Question.Index.Value;
            BindingContext = this;
        }

        private void Submit_OnClicked(object sender, EventArgs e)
        {
            if (_originalQuestion != null)
                _questionList.Remove(_originalQuestion);

            Question.Index = _index;

            _questionList.Insert(_index, Question);

            Navigation.PopAsync();
        }
    }
}