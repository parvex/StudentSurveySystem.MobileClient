using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Force.DeepCloner;
using Mapster;
using MobileClient.Extensions;
using MobileClient.Models;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;

namespace MobileClient.Views.MySurveys
{
    public class QuestionViewModel : ViewModelBase
    {

        private readonly ObservableCollection<QuestionVm> _questionList;
        private readonly QuestionVm _originalQuestion;
        private string _questionText;
        public QuestionType? _questionType { get; set; }
        /// <summary>
        /// Values for mutli or single select
        /// </summary>
        public ObservableCollection<string> Values{ get; set; } = new ObservableCollection<string>();
        public string QuestionText {
            get => _questionText; 
            set
            {
                if (_questionList.Any(x => x.QuestionText == value && !x.Equals(_originalQuestion)))
                    ErrorDictionary["QuestionText"] = "Question named like this already exists.";
                else
                    ErrorDictionary["QuestionText"] = "";

                _questionText = value;
                OnPropertyChanged(nameof(QuestionText));
            }
        }
        public List<string> QuestionTypes { get; } = Enum.GetNames(typeof(QuestionType)).Select(b => b.SplitCamelCase()).ToList();
        public AutoObsDictionary<string, string> ErrorDictionary { get; set; } = new AutoObsDictionary<string, string>();

        public QuestionType? QuestionType
        {
            get => _questionType;
            set
            {
                ErrorDictionary["QuestionType"] = "";
                foreach (var pair in VisibleDictionary.ToList())
                {
                    VisibleDictionary[pair.Key] = false;
                }

                switch (value)
                {
                    case StudentSurveySystem.ApiClient.Model.QuestionType.Text:
                        VisibleDictionary["Text"] = true;
                        break;
                    case StudentSurveySystem.ApiClient.Model.QuestionType.SingleSelect:
                    case StudentSurveySystem.ApiClient.Model.QuestionType.MultipleSelect:
                        VisibleDictionary["MultipleSelect"] = true;
                        break;
                    case StudentSurveySystem.ApiClient.Model.QuestionType.Numeric:
                        VisibleDictionary["Numeric"] = true;
                        break;
                    case StudentSurveySystem.ApiClient.Model.QuestionType.Date:
                        VisibleDictionary["Date"] = true;
                        break;
                    case StudentSurveySystem.ApiClient.Model.QuestionType.Boolean:
                        break;
                    case null:
                        break;
                    default:
                        ErrorDictionary["QuestionType"] = "Please select question type.";
                        break;
                }

                _questionType = value;
                OnPropertyChanged(nameof(QuestionType));
            }
        }

        public AutoObsDictionary<string, bool> VisibleDictionary { get; set; } = new AutoObsDictionary<string, bool>();

        public ValidationConfigVm ValidationConfig { get; set; }

        public string Index { get; set; }

        public QuestionViewModel()
        {
            QuestionTypes.Insert(0, "Select type");
            Commands["DeleteValue"] = new Command((object selectedItem) => { var item = (string) selectedItem; Values.Remove(item); });
            ValidationConfig = new ValidationConfigVm {ErrorDictionary = ErrorDictionary};
        }

        public void AddOrUpdateValue(string value, int? index = null)
        {
            if(!index.HasValue)
                Values.Add(value);
            else
                Values[index.Value] = value;
        }

        public QuestionViewModel(ObservableCollection<QuestionVm> questionList) : this()
        {
            _questionList = questionList;
            Index = (questionList.Count+1).ToString();
        }

        public QuestionViewModel(QuestionVm question, ObservableCollection<QuestionVm> questionList) : this()
        {
            _questionList = questionList;
            _originalQuestion = question;
            var copied = _originalQuestion.DeepClone();
            QuestionType = copied.QuestionType;
            QuestionText = copied.QuestionText;
            Values = copied.Values != null ? new ObservableCollection<string>(copied.Values) : Values; 
            Index = (copied.Index.Value+1).ToString();
            ValidationConfig = copied.ValidationConfig.Adapt<ValidationConfigVm>();
            ValidationConfig.MinDateValue = copied.ValidationConfig.MinDateValue;
            ValidationConfig.MaxDateValue = copied.ValidationConfig.MaxDateValue;
            ValidationConfig.ErrorDictionary = ErrorDictionary;
        }

        public bool Submit()
        {
            if (ErrorDictionary.Any(x => !string.IsNullOrEmpty(x.Value)))
                return false;

            QuestionVm question;
            if (_originalQuestion != null)
            {
                _questionList.Remove(_originalQuestion);
                question = _originalQuestion;
            }
            else
            {
                question = new QuestionVm();
            }

            question.Index = string.IsNullOrEmpty(Index) ? _questionList.Count : int.Parse(Index);
            question.QuestionText = QuestionText;
            question.QuestionType = QuestionType;
            question.Values = Values.ToList();
            question.ValidationConfig = ValidationConfig.ToDto();
            if (question.Index.Value > _questionList.Count)
                _questionList.Add(question);
            else
                _questionList.Insert(question.Index.Value, question);
            for (int i = 0; i < _questionList.Count; ++i)
            {
                _questionList[i].Index = i + 1;
            }
            return true;
        }
    }
}