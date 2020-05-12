using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Force.DeepCloner;
using MobileClient.Annotations;
using MobileClient.Extensions;
using MobileClient.Models;
using StudentSurveySystem.ApiClient.Model;

namespace MobileClient.Views.MySurveys
{
    public class QuestionViewModel : ViewModelBase
    {

        private readonly ObservableCollection<QuestioDtoModel> _questionList;
        private readonly QuestioDtoModel _originalQuestion;
        private string _questionText;
        public QuestionType? _questionType { get; set; }

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

                _questionType = value;
                OnPropertyChanged(nameof(QuestionType));
            }
        }

        public ValidationConfig ValidationConfig { get; set; }

        public string Index { get; set; }

        public QuestionViewModel()
        {
            QuestionTypes.Insert(0, "Select type");
        }

        public QuestionViewModel(ObservableCollection<QuestioDtoModel> questionList) : this()
        {
            _questionList = questionList;
            Index = questionList.Count.ToString();
        }

        public QuestionViewModel(QuestioDtoModel question, ObservableCollection<QuestioDtoModel> questionList) : this()
        {
            _questionList = questionList;
            _originalQuestion = question;
            var copied = _originalQuestion.DeepClone();
            QuestionType = copied.QuestionType;
            QuestionText = copied.QuestionText;
            Index = copied.Index.Value.ToString();
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
            if(question.Index.Value >= _questionList.Count)
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