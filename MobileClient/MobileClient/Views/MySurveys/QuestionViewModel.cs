using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Force.DeepCloner;
using MobileClient.Extensions;
using MobileClient.Models;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;

namespace MobileClient.Views.MySurveys
{
    public class QuestionViewModel : ViewModelBase
    {

        private readonly ObservableCollection<QuestioDtoModel> _questionList;
        private readonly QuestioDtoModel _originalQuestion;
        private string _questionText;
        public QuestionType? _questionType { get; set; }
        /// <summary>
        /// Values for mutli or single select
        /// </summary>
        public ObservableCollection<string> Values{ get; set; } = new ObservableCollection<string>();
        public bool ValuesVisible { get; set; }
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
        public ErrorDictionary ErrorDictionary { get; set; } = new ErrorDictionary();

        public QuestionType? QuestionType
        {
            get => _questionType;
            set
            {
                if (value != null && (int) value == 0)
                    ErrorDictionary["QuestionType"] = "Please select question type.";
                else
                    ErrorDictionary["QuestionType"] = "";

                if (value == StudentSurveySystem.ApiClient.Model.QuestionType.MultipleSelect || value == StudentSurveySystem.ApiClient.Model.QuestionType.SingleSelect)
                    ValuesVisible = true;
                else
                    ValuesVisible = false;

                _questionType = value;
                OnPropertyChanged(nameof(QuestionType));
            }
        }

        public ValidationConfig ValidationConfig { get; set; }

        public string Index { get; set; }

        public QuestionViewModel()
        {
            QuestionTypes.Insert(0, "Select type");
            Commands["DeleteValue"] = new Command((object selectedItem) => { var item = (string) selectedItem; Values.Remove(item); });
        }

        public void AddOrUpdateValue(string value, int? index = null)
        {
            if(!index.HasValue)
                Values.Add(value);
            else
                Values[index.Value] = value;
        }

        public QuestionViewModel(ObservableCollection<QuestioDtoModel> questionList) : this()
        {
            _questionList = questionList;
            Index = (questionList.Count+1).ToString();
        }

        public QuestionViewModel(QuestioDtoModel question, ObservableCollection<QuestioDtoModel> questionList) : this()
        {
            _questionList = questionList;
            _originalQuestion = question;
            var copied = _originalQuestion.DeepClone();
            QuestionType = copied.QuestionType;
            QuestionText = copied.QuestionText;
            Values = copied.Values != null ? new ObservableCollection<string>(copied.Values) : Values; 
            Index = (copied.Index.Value+1).ToString();
        }

        public bool Submit()
        {
            if (ErrorDictionary.Any(x => !string.IsNullOrEmpty(x.Value)))
                return false;

            QuestioDtoModel question;
            if (_originalQuestion != null)
            {
                _questionList.Remove(_originalQuestion);
                question = _originalQuestion;
            }
            else
            {
                question = new QuestioDtoModel();
            }

            question.Index = string.IsNullOrEmpty(Index) ? _questionList.Count : int.Parse(Index);
            
            question.QuestionText = QuestionText;
            question.QuestionType = QuestionType;
            question.Values = Values.ToList();
            if(question.Index.Value > _questionList.Count)
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