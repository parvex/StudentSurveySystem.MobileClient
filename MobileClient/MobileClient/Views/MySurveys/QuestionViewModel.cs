using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using IO.Swagger.Model;
using Mapster;
using MobileClient.Extensions;
using MobileClient.Models;
using Xamarin.Forms;

namespace MobileClient.Views.MySurveys
{
    public class QuestionViewModel : ViewModelBase
    {

        private readonly ObservableCollection<QuestionModel> _questionList;
        private readonly QuestionModel _originalQuestion;
        private string _questionText;
        public QuestionType _questionType { get; set; }
        /// <summary>
        /// Values for mutli or single select
        /// </summary>
        public ObservableCollection<StringDoubleNullableValueTuple> Values{ get; set; } = new ObservableCollection<StringDoubleNullableValueTuple>();
        public string QuestionText {
            get => _questionText; 
            set
            {
                if (string.IsNullOrEmpty(value))
                    ErrorDictionary["QuestionText"] = "Please specify question text.";
                else
                    ErrorDictionary["QuestionText"] = "";

                _questionText = value;
                OnPropertyChanged(nameof(QuestionText));
            }
        }
        public List<string> QuestionTypes { get; } = Enum.GetNames(typeof(QuestionType)).Select(b => b.SplitCamelCase()).ToList();
        public AutoObsDictionary<string, string> ErrorDictionary { get; set; } = new AutoObsDictionary<string, string>();

        public QuestionType QuestionType
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
                    case QuestionType.Text:
                        VisibleDictionary["Text"] = true;
                        break;
                    case QuestionType.SingleSelect:
                    case QuestionType.MultipleSelect:
                    case QuestionType.ValuedSingleSelect:
                        VisibleDictionary["MultipleSelect"] = true;

                        if(value == QuestionType.ValuedSingleSelect)
                            VisibleDictionary["ValuedSingleSelect"] = true;
                        break;
                    case QuestionType.Numeric:
                        VisibleDictionary["Numeric"] = true;
                        break;
                    case QuestionType.Date:
                        VisibleDictionary["Date"] = true;
                        break;
                    case QuestionType.Boolean:
                        break;
                    default:
                        ErrorDictionary["QuestionType"] = "Please select question type.";
                        break;
                }

                _questionType = value;
                OnPropertyChanged(nameof(QuestionType));
            }
        }

        public bool Required { get; set; }

        public AutoObsDictionary<string, bool> VisibleDictionary { get; set; } = new AutoObsDictionary<string, bool>();

        public ValidationConfigVm ValidationConfig { get; set; }

        public string Index { get; set; }

        public QuestionViewModel()
        {
            QuestionTypes.Insert(0, "Select type");
            Commands["DeleteValue"] = new Command((object selectedItem) => { var item = (StringDoubleNullableValueTuple) selectedItem;  Values.Remove(item); });
            ValidationConfig = new ValidationConfigVm {ErrorDictionary = ErrorDictionary};
            ErrorDictionary["QuestionType"] = "Please select question type.";
            ErrorDictionary["QuestionText"] = "Please specify question text.";
        }

        public void AddOrUpdateValue(string selectText, double? selectValue, int? index = null)
        {
            if (QuestionType != QuestionType.ValuedSingleSelect)
                selectValue = null;
            if(!index.HasValue)
                Values.Add(new StringDoubleNullableValueTuple(selectText, selectValue));
            else
                Values[index.Value] = new StringDoubleNullableValueTuple(selectText, selectValue);
        }

        public QuestionViewModel(ObservableCollection<QuestionModel> questionList) : this()
        {
            _questionList = questionList;
            Index = (questionList.Count+1).ToString();
        }

        public QuestionViewModel(QuestionModel question, ObservableCollection<QuestionModel> questionList) : this()
        {
            _questionList = questionList;
            _originalQuestion = question;
            var copied = _originalQuestion.Clone();
            QuestionType = copied.QuestionType;
            Required = copied.Required.Value;
            QuestionText = copied.QuestionText;
            Values = copied.Values != null ? new ObservableCollection<StringDoubleNullableValueTuple>(copied.Values) : Values; 
            Index = (copied.Index.Value).ToString();
            ValidationConfig = copied.ValidationConfig.Adapt<ValidationConfigVm>();
            ValidationConfig.MinNumericValue = copied.ValidationConfig.MinNumericValue.ToString();
            ValidationConfig.MaxNumericValue = copied.ValidationConfig.MaxNumericValue.ToString();            
            ValidationConfig.MinDateValue = copied.ValidationConfig.MinDateValue;
            ValidationConfig.MaxDateValue = copied.ValidationConfig.MaxDateValue;
            ValidationConfig.Regex = copied.ValidationConfig.Regex;
            ValidationConfig.ErrorDictionary = ErrorDictionary;
        }

        public bool Submit()
        {
            var maxNumericValue = double.TryParse(ValidationConfig.MaxNumericValue, out var tempValMax) ? tempValMax : (double?)null;
            var minNumericValue = double.TryParse(ValidationConfig.MinNumericValue, out var tempValMin) ? tempValMin : (double?)null;
            ErrorDictionary["NumericRange"] = minNumericValue > maxNumericValue ? "Min value must be lesser than max" : null;

            if (ErrorDictionary.Any(x => !string.IsNullOrEmpty(x.Value)))
                return false;

            QuestionModel question;
            if (_originalQuestion != null)
            {
                _questionList.RemoveAt(_originalQuestion.Index.Value-1);
                question = _originalQuestion;
            }
            else
            {
                question = new QuestionModel();
            }

            question.Index = string.IsNullOrEmpty(Index) ? _questionList.Count : int.Parse(Index);
            question.QuestionText = QuestionText;
            question.QuestionType = QuestionType;
            question.Required = Required;
            question.Values = Values.ToList();
            question.ValidationConfig = ValidationConfig.ToDto();

            if (question.Index.Value > _questionList.Count)
                _questionList.Add(question);
            else
                _questionList.Insert(question.Index.Value - 1, question);
            for (int i = 0; i < _questionList.Count; ++i)
            {
                _questionList[i].Index = i + 1;
            }
            return true;
        }
    }
}